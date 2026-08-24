using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using Google.Protobuf;
using kRPC.Client.Boost.Connection.Schema;
using kRPC.Client.Boost.Exceptions;
using kRPC.Client.Boost.Services;
using MathNet.Spatial.Euclidean;
using DictionaryEntry = System.Collections.DictionaryEntry;
using Stream = System.IO.Stream;
using Type = System.Type;

namespace kRPC.Client.Boost.Connection
{
    /// <summary>
    /// Methods for encoding and decoding messages for kRPCs protocolo bufers over TCP/IP protocol.
    /// </summary>
    internal static class Codec
    {
        /// <summary>
        /// Encodes a non-null object using the protocol buffer encoding scheme.
        /// </summary>
        /// <param name="value">The value to encode</param>
        /// <returns>The encoded value as a ByteString</returns>
        public static ByteString Encode(object value)
        {
            return Encode(value, value.GetType());
        }

        /// <summary>
        /// Encodes a potentially null object using the protocol buffer encoding scheme.
        /// </summary>
        /// <param name="value">The value to encode</param>
        /// <param name="type">The type of the value</param>
        /// <returns>The encoded value as a ByteString</returns>
        public static ByteString Encode(object? value, Type type)
        {
            using var buffer = new MemoryStream();
            var stream = new CodedOutputStream(buffer, true);
            return EncodeObject(value, type, buffer, stream);
        }
        
        /// <summary>
        /// Decode a value of the given type.
        /// </summary>
        public static object? Decode(ByteString value, Type type, IConnectionMultiplexer client)
        {
            if (ReferenceEquals(type, null))
                throw new CodecException($"{nameof(type)} should not be null");
            
            var stream = value.CreateCodedInput();
            if (type.IsEnum)
                return Enum.ToObject(type, stream.ReadSInt32());
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Double:
                    return stream.ReadDouble();
                case TypeCode.Single:
                    return stream.ReadFloat();
                case TypeCode.Int32:
                    return stream.ReadSInt32();
                case TypeCode.Int64:
                    return stream.ReadSInt64();
                case TypeCode.UInt32:
                    return stream.ReadUInt32();
                case TypeCode.UInt64:
                    return stream.ReadUInt64();
                case TypeCode.Boolean:
                    return stream.ReadBool();
                case TypeCode.String:
                    return stream.ReadString();
            }

            if (type == typeof(byte[]))
                return stream.ReadBytes().ToByteArray();
            
            if (IsARemoteObjectType(type))
            {
                if (client == null)
                    throw new ArgumentException("Client not passed when decoding remote object");

                var id = stream.ReadUInt64();
                if (id == 0)
                    return null;

                return RemoteObjectFactory.Create(type, client, id);
            }

            if (IsATupleType(type))
                return DecodeTuple(stream, type, client);
            if (IsAnArrayType(type))
                return DecodeArray(stream, type, client);
            if (IsAListType(type))
                return DecodeList(stream, type, client);
            if (IsASetType(type))
                return DecodeSet(stream, type, client);
            if (IsADictionaryType(type))
                return DecodeDictionary(stream, type, client);
            if (IsAVectorType(type))
                return DecodeVector(stream, client);
            if (IsAQuaternionType(type))
                return DecodeQuaternion(stream, client);
            if (IsAMessageType(type))
            {
                var message = (IMessage)(Activator.CreateInstance(type)
                    ?? throw new CodecException("Unable to determine message type"));
                message.MergeFrom(stream);
                return message;
            }

            //if (type != typeof(Event)) TODO sort this when we have an event type
            //    throw new ArgumentException(type + " is not a serializable type");
            
            var @event = new Schema.Event();
            @event.MergeFrom(stream);
            return null; // return new Event((Connection)client, @event); TODO sort this - presumably needs an event type to exist in the public API
        }

        private static ByteString EncodeObject(object? value, Type type, MemoryStream buffer, CodedOutputStream stream)
        {
            buffer.SetLength(0);
            
            if (value != null && !type.IsInstanceOfType(value))
                throw new CodecException("Value of type " + value.GetType() + " cannot be encoded to type " + type);
            
            if (value == null && !IsARemoteObjectType(type) && !IsACollectionType(type))
                throw new CodecException($"Null cannot be encoded to type {type}");
            
            switch (value)
            {
                case null:
                    stream.WriteUInt64(0);
                    break;
                case Enum:
                    stream.WriteSInt32((int)value);
                    break;
                default:
                    switch (Type.GetTypeCode(type)) 
                    {
                        case TypeCode.Double:
                            stream.WriteDouble((double)value);
                            break;
                        case TypeCode.Single:
                            stream.WriteFloat((float)value);
                            break;
                        case TypeCode.Int32:
                            stream.WriteSInt32((int)value);
                            break;
                        case TypeCode.Int64:
                            stream.WriteSInt64((long)value);
                            break;
                        case TypeCode.UInt32:
                            stream.WriteUInt32((uint)value);
                            break;
                        case TypeCode.UInt64:
                            stream.WriteUInt64((ulong)value);
                            break;
                        case TypeCode.Boolean:
                            stream.WriteBool((bool)value);
                            break;
                        case TypeCode.String:
                            stream.WriteString((string)value);
                            break;
                        default:
                            if (type == typeof(byte[]))
                                stream.WriteBytes(ByteString.CopyFrom((byte[])value));
                            else if (IsARemoteObjectType(type))
                                stream.WriteUInt64(((RemoteObject)value).Id);
                            else if (IsLambdaExpressionType(type))
                                EncodeLambdaExpression(value, buffer);
                            else if (IsATupleType(type))
                                EncodeTuple(value, type, buffer);
                            else if (IsAnArrayType(type) || IsAListType(type))
                                EncodeList(value, type, buffer); // Works because array types also implement IList
                            else if (IsASetType(type))
                                EncodeSet(value, type, buffer);
                            else if (IsADictionaryType(type))
                                EncodeDictionary(value, type, buffer);
                            else if (IsAVectorType(type))
                                EncodeVector(value, buffer);
                            else if (IsAQuaternionType(type))
                                EncodeQuaternion(value, buffer);
                            else if (IsAMessageType(type))
                                ((IMessage)value).WriteTo(buffer);
                            else
                                throw new ArgumentException(type + " is not a serializable type");
                            break;
                    }

                    break;
            }

            stream.Flush();
            return ByteString.CopyFrom(buffer.GetBuffer(), 0, (int)buffer.Length);
        }
        
        internal static bool IsAGenericType(Type type, Type genericType)
        {
            var t = type;
            while (!ReferenceEquals(t, null))
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == genericType)
                    return true;
                
                if (t.GetInterfaces().Any(intType => IsAGenericType(intType, genericType)))
                    return true;
                
                t = t.BaseType;
            }
            
            return false;
        }

        private static bool IsARemoteObjectType(Type type)
        {
            return type.IsAssignableTo(typeof(RemoteObject));
        }

        private static bool IsAMessageType(Type type)
        {
            return type.IsAssignableTo(typeof(IMessage));
        }
        
        internal static bool IsACollectionType(Type type)
        {
            return IsATupleType(type) 
                   || IsAnArrayType(type) 
                   || IsAListType(type) 
                   || IsASetType(type) 
                   || IsADictionaryType(type);
        }

        private static bool IsLambdaExpressionType(Type type)
        {
            return typeof(LambdaExpression).IsAssignableFrom(type);
        }

        private static void EncodeLambdaExpression(object value, Stream stream)
        {
            var procedureCall = Connection.GetCall((LambdaExpression)value);

            ByteString encodedCall;
            using (var internalBuffer = new MemoryStream())
            {
                var internalStream = new CodedOutputStream(internalBuffer);
                encodedCall = EncodeObject(procedureCall, typeof(ProcedureCall), internalBuffer, internalStream);
            }
            
            encodedCall.WriteTo(stream);
        }
        
        internal static bool IsATupleType(Type type)
        {
            return
                IsAGenericType(type, typeof(Tuple<>)) ||
                IsAGenericType(type, typeof(Tuple<,>)) ||
                IsAGenericType(type, typeof(Tuple<,,>)) ||
                IsAGenericType(type, typeof(Tuple<,,,>)) ||
                IsAGenericType(type, typeof(Tuple<,,,,>)) ||
                IsAGenericType(type, typeof(Tuple<,,,,,>)) ||
                IsAGenericType(type, typeof(Tuple<,,,,,,>)) ||
                IsAGenericType(type, typeof(Tuple<,,,,,,,>));
        }
        
        private static void EncodeTuple(object value, Type type, Stream stream)
        {
            var encodedTuple = new Schema.Tuple();
            var valueTypes = type.GetGenericArguments();
            var genericType = Type.GetType("System.Tuple`" + valueTypes.Length);
            var tupleType = genericType?.MakeGenericType(valueTypes)
                            ?? throw new CodecException("Unable to determine tuple type");
            using (var internalBuffer = new MemoryStream()) 
            {
                var internalStream = new CodedOutputStream(internalBuffer);
                for (var i = 0; i < valueTypes.Length; i++) 
                {
                    var property = tupleType.GetProperty("Item" + (i + 1));
                    var item = property?.GetGetMethod()?.Invoke(value, null)
                               ?? throw new CodecException("Unable to determine tuple property");
                    encodedTuple.Items.Add(EncodeObject(item, valueTypes[i], internalBuffer, internalStream));
                }
            }
            encodedTuple.WriteTo(stream);
        }

        private static object DecodeTuple(CodedInputStream stream, Type type, IConnectionMultiplexer client)
        {
            var encodedTuple = ParseEncodedStream(Schema.Tuple.Parser, stream);
            var genericArgs = type.GetGenericArguments();
            var genericType = Type.GetType("System.Tuple`" + genericArgs.Length);
            if (genericType == null)
                throw new CodecException($"Unable to find tuple type with {genericArgs.Length} generic arguments");
            
            var values = new object?[genericArgs.Length];
            for (var i = 0; i < genericArgs.Length; i++)
            {
                var item = encodedTuple.Items[i];
                values[i] = Decode(item, genericArgs[i], client);
            }

            var constructor = GetGenericConstructor(type, genericType, false);
            var tuple = constructor.Invoke(values);
            return tuple;
        }
        
        internal static bool IsAListType(Type type)
        {
            return IsAGenericType(type, typeof(IList<>)) && !IsAnArrayType(type);
        }

        internal static bool IsAnArrayType(Type type)
        {
            return type.IsAssignableTo(typeof(Array));
        }
        
        private static void EncodeList(object value, Type type, Stream stream)
        {
            var encodedList = new Schema.List();
            var list = (IList)value;
            var listInterface = type.GetInterface("IList`1") 
                                ?? throw new CodecException("Unable to find generic IList interface on type");
            var valueType = listInterface.GetGenericArguments().Single();
            using (var internalBuffer = new MemoryStream())
            {
                var internalStream = new CodedOutputStream(internalBuffer);
                foreach (var item in list)
                    encodedList.Items.Add(EncodeObject(item, valueType, internalBuffer, internalStream));
            }
            encodedList.WriteTo(stream);
        }

        private static object DecodeList(CodedInputStream stream, Type type, IConnectionMultiplexer client)
        {
            var constructor = GetGenericConstructor(type, typeof(IList<>), true);
            var encodedList = ParseEncodedStream(Schema.List.Parser, stream);
            var itemType = type.GetGenericArguments().Single();
            
            var list = (IList)constructor
                .Invoke(null);
            
            foreach (var item in encodedList.Items)
                list.Add(Decode(item, itemType, client));
            
            return list;
        }

        private static object DecodeArray(CodedInputStream stream, Type type, IConnectionMultiplexer client)
        {
            // Array constructors have a single parameter for capacity
            var constructor = type.GetConstructor([typeof(int)])
                ?? throw new CodecException("Unable to find array constructor");

            var encodedArray = ParseEncodedStream(Schema.List.Parser, stream);
            var array = (IList)constructor.Invoke([encodedArray.Items.Count]);
            var listInterface = type.GetInterface("IList`1")
                ?? throw new CodecException("Unable to find generic IList interface on array type");
            var itemType = listInterface.GetGenericArguments().Single();

            for (var i = 0; i < encodedArray.Items.Count; i++)
                array[i] = Decode(encodedArray.Items[i], itemType, client);

            return array;
        }
        
        internal static bool IsASetType(Type type)
        {
            return IsAGenericType(type, typeof(ISet<>));
        }
        
        private static void EncodeSet(object value, Type type, Stream stream)
        {
            var encodedSet = new Schema.Set();
            var set = (IEnumerable)value;
            var valueType = type.GetGenericArguments().Single();
            using (var internalBuffer = new MemoryStream())
            {
                var internalStream = new CodedOutputStream(internalBuffer);
                foreach (var item in set)
                    encodedSet.Items.Add(EncodeObject(item, valueType, internalBuffer, internalStream));
            }
            encodedSet.WriteTo(stream);
        }

        private static object DecodeSet(CodedInputStream stream, Type type, IConnectionMultiplexer client)
        {
            var encodedSet = ParseEncodedStream(Schema.Set.Parser, stream);
            var constructor = GetGenericConstructor(type, typeof(HashSet<>), true);
            
            var set = (IEnumerable)constructor.Invoke(null);
            var addMethod = type.GetMethod("Add") 
                            ?? throw new CodecException("Unable to find add method on HashSet");
            
            foreach (var item in encodedSet.Items) 
            {
                var decodedItem = Decode(item, type.GetGenericArguments().Single(), client);
                addMethod.Invoke(set, [decodedItem]);
            }
            
            return set;
        }
        
        internal static bool IsADictionaryType(Type type)
        {
            return IsAGenericType(type, typeof(IDictionary<,>));
        }
        
        private static void EncodeDictionary(object value, Type type, Stream stream)
        {
            if (!type.IsInstanceOfType(value) || !typeof(IDictionary).IsAssignableFrom(type))
                throw new CodecException($"{value.GetType().Name} and {type.Name} are not compatible with writing a dictionary");
                
            var keyType = type.GetGenericArguments()[0];
            var valueType = type.GetGenericArguments()[1];
            var encodedDictionary = new Schema.Dictionary();
            
            using (var internalBuffer = new MemoryStream()) 
            {
                var internalStream = new CodedOutputStream(internalBuffer);
                foreach (DictionaryEntry entry in (IDictionary)value) 
                {
                    var encodedEntry = new Schema.DictionaryEntry
                    {
                        Key = EncodeObject(entry.Key, keyType, internalBuffer, internalStream),
                        Value = EncodeObject(entry.Value, valueType, internalBuffer, internalStream)
                    };
                    encodedDictionary.Entries.Add(encodedEntry);
                }
            }
            encodedDictionary.WriteTo(stream);
        }

        private static object DecodeDictionary(CodedInputStream stream, Type type, IConnectionMultiplexer client)
        {
            var encodedDictionary = ParseEncodedStream(Schema.Dictionary.Parser, stream);
            var constructor = GetGenericConstructor(type, typeof(Dictionary<,>), true);
            
            var dictionary = (IDictionary)constructor.Invoke(null);
            
            foreach (var entry in encodedDictionary.Entries) 
            {
                var key = Decode(entry.Key, type.GetGenericArguments()[0], client);
                var value = Decode(entry.Value, type.GetGenericArguments()[1], client);
                dictionary[key ?? throw new CodecException("Dictionary keys cannot be null")] = value;
            }
            
            return dictionary;
        }

        private static bool IsAVectorType(Type type)
        {
            return type == typeof(Vector3D);
        }

        private static void EncodeVector(object value, Stream stream)
        {
            if (value is not Vector3D v)
                throw new CodecException("Can't encode a non-vector as a vector");
            
            var tuple = new Tuple<double, double, double>(v.X, v.Y, v.Z);
            EncodeTuple(tuple, tuple.GetType(), stream);
        }

        private static object DecodeVector(CodedInputStream stream, IConnectionMultiplexer client)
        {
            var tuple = DecodeTuple(stream, typeof(Tuple<double, double, double>), client);
            
            if (tuple is not Tuple<double, double, double> t)
                throw new CodecException("Did not receive a vector tuple when decoding a vector tuple");
            
            return new Vector3D(t.Item1, t.Item2, t.Item3);
        }

        private static bool IsAQuaternionType(Type type)
        {
            return type == typeof(Quaternion);
        }

        private static void EncodeQuaternion(object value, Stream stream)
        {
            if (value is not Quaternion q)
                throw new CodecException("Can't encode a non-quaternion as a quaternion");
            
            var tuple = new Tuple<double, double, double, double>(q.Real, q.ImagX, q.ImagY, q.ImagZ);
            EncodeTuple(tuple, tuple.GetType(), stream);
        }

        private static object DecodeQuaternion(CodedInputStream stream, IConnectionMultiplexer client)
        {
            var tuple = DecodeTuple(stream, typeof(Tuple<double, double, double, double>), client);
            
            if (tuple is not Tuple<double, double, double, double> t)
                throw new CodecException("Did not receive a quaternion as a quaternion");

            return new Quaternion(t.Item1, t.Item2, t.Item3, t.Item4);
        }

        private static ConstructorInfo GetGenericConstructor(Type type, Type expectedGenericType, bool emptyTypeConstructor)
        {
            if (!IsAGenericType(type, expectedGenericType))
                throw new CodecException($"The provided type {type.Name} is not assignable to type {expectedGenericType.Name}");
            
            var args = type.GetGenericArguments();
            var constructor = type.GetConstructor(emptyTypeConstructor ? Type.EmptyTypes : args);

            return constructor == null 
                ? throw new CodecException($"Unable to find constructor for type {type.Name}") 
                : constructor;
        }
        
        private static T ParseEncodedStream<T>(MessageParser<T> parser, CodedInputStream stream) where T : IMessage<T>
        {
            var result = parser.ParseFrom(stream);
            return result ?? throw new CodecException($"Unable to parse {typeof(T).Name} from stream");
        }
    }
}

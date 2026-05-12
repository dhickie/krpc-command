using System.Collections;
using System.Reflection;
using Google.Protobuf;
using kRPC.Client.Boost.Exceptions;
using Type = System.Type;

namespace kRPC.Client.Boost.Connection
{
    /// <summary>
    /// Methods for encoding and decoding messages for kRPCs protocolo bufers over TCP/IP protocol.
    /// </summary>
    internal static class Encoder
    {
        /// <summary>
        /// Encode an object of the given type using the protocol buffer encoding scheme.
        /// Should not be called directly. This interface is used by service client stubs.
        /// </summary>
        public static ByteString Encode (object value, Type type)
        {
            using var buffer = new MemoryStream ();
            var stream = new CodedOutputStream (buffer, true);
            return EncodeObject (value, type, buffer, stream);
        }

        private static ByteString EncodeObject (object? value, Type type, MemoryStream buffer, CodedOutputStream stream)
        {
            buffer.SetLength (0);
            if (value != null && !type.IsInstanceOfType (value))
                throw new CodecException("Value of type " + value.GetType () + " cannot be encoded to type " + type);
            switch (value)
            {
                //case null when !type.IsSubclassOf (typeof(RemoteObject)) && !IsACollectionType (type):
                //    throw new ArgumentException ("null cannot be encoded to type " + type); TODO sort this out when we have a base class for remote objects
                case null:
                    stream.WriteUInt64 (0);
                    break;
                case Enum:
                    stream.WriteSInt32 ((int)value);
                    break;
                default:
                    switch (Type.GetTypeCode (type)) 
                    {
                        case TypeCode.Double:
                            stream.WriteDouble ((double)value);
                            break;
                        case TypeCode.Single:
                            stream.WriteFloat ((float)value);
                            break;
                        case TypeCode.Int32:
                            stream.WriteSInt32 ((int)value);
                            break;
                        case TypeCode.Int64:
                            stream.WriteSInt64 ((long)value);
                            break;
                        case TypeCode.UInt32:
                            stream.WriteUInt32 ((uint)value);
                            break;
                        case TypeCode.UInt64:
                            stream.WriteUInt64 ((ulong)value);
                            break;
                        case TypeCode.Boolean:
                            stream.WriteBool ((bool)value);
                            break;
                        case TypeCode.String:
                            stream.WriteString ((string)value);
                            break;
                        default:
                            if (type == typeof(byte[]))
                                stream.WriteBytes (ByteString.CopyFrom ((byte[])value));
                            //else if (IsAClassType (type))
                                // stream.WriteUInt64 (((RemoteObject)value).id); TODO fix this once we have a base type for remote objects
                            else if (IsATupleType (type))
                                WriteTuple (value, type, buffer);
                            else if (IsAListType (type))
                                WriteList (value, type, buffer);
                            else if (IsASetType (type))
                                WriteSet (value, type, buffer);
                            else if (IsADictionaryType (type))
                                WriteDictionary (value, type, buffer);
                            else if (IsAMessageType (type))
                                ((IMessage)value).WriteTo (buffer);
                            else
                                throw new ArgumentException (type + " is not a serializable type");
                            break;
                    }

                    break;
            }

            stream.Flush ();
            return ByteString.CopyFrom (buffer.GetBuffer (), 0, (int)buffer.Length);
        }

        private static void WriteTuple (object value, Type type, Stream stream)
        {
            var encodedTuple = new Schema.Tuple ();
            var valueTypes = type.GetGenericArguments ();
            var genericType = Type.GetType ("System.Tuple`" + valueTypes.Length);
            var tupleType = genericType?.MakeGenericType (valueTypes)
                ?? throw new CodecException("Unable to determine tuple type");
            using (var internalBuffer = new MemoryStream ()) 
            {
                var internalStream = new CodedOutputStream (internalBuffer);
                for (var i = 0; i < valueTypes.Length; i++) 
                {
                    var property = tupleType.GetProperty ("Item" + (i + 1));
                    var item = property?.GetGetMethod ()?.Invoke (value, null)
                        ?? throw new CodecException("Unable to determine tuple property");
                    encodedTuple.Items.Add (EncodeObject (item, valueTypes [i], internalBuffer, internalStream));
                }
            }
            encodedTuple.WriteTo (stream);
        }

        private static void WriteList (object value, Type type, Stream stream)
        {
            var encodedList = new Schema.List ();
            var list = (IList)value;
            var valueType = type.GetGenericArguments ().Single ();
            using (var internalBuffer = new MemoryStream ()) 
            {
                var internalStream = new CodedOutputStream (internalBuffer);
                foreach (var item in list)
                    encodedList.Items.Add (EncodeObject (item, valueType, internalBuffer, internalStream));
            }
            encodedList.WriteTo (stream);
        }

        private static void WriteSet (object value, Type type, Stream stream)
        {
            var encodedSet = new Schema.Set ();
            var set = (IEnumerable)value;
            var valueType = type.GetGenericArguments ().Single ();
            using (var internalBuffer = new MemoryStream ())
            {
                var internalStream = new CodedOutputStream (internalBuffer);
                foreach (var item in set)
                    encodedSet.Items.Add (EncodeObject (item, valueType, internalBuffer, internalStream));
            }
            encodedSet.WriteTo (stream);
        }

        private static void WriteDictionary (object value, Type type, Stream stream)
        {
            if (!type.IsInstanceOfType(value) || typeof(IDictionary).IsAssignableFrom(type))
                throw new CodecException($"{value.GetType().Name} and {type.Name} are not compatible with writing a dictionary");
                
            var keyType = type.GetGenericArguments () [0];
            var valueType = type.GetGenericArguments () [1];
            var encodedDictionary = new Schema.Dictionary ();
            
            using (var internalBuffer = new MemoryStream ()) 
            {
                var internalStream = new CodedOutputStream(internalBuffer);
                foreach (DictionaryEntry entry in (IDictionary) value) 
                {
                    var encodedEntry = new Schema.DictionaryEntry
                    {
                        Key = EncodeObject (entry.Key, keyType, internalBuffer, internalStream),
                        Value = EncodeObject (entry.Value, valueType, internalBuffer, internalStream)
                    };
                    encodedDictionary.Entries.Add (encodedEntry);
                }
            }
            encodedDictionary.WriteTo (stream);
        }

        /// <summary>
        /// Decode a value of the given type.
        /// Should not be called directly. This interface is used by service client stubs.
        /// </summary>
        public static object Decode (ByteString value, Type type, IConnection client)
        {
            if (ReferenceEquals (type, null))
                throw new CodecException($"{nameof(type)} should not be null");
            
            var stream = value.CreateCodedInput ();
            if (type.IsEnum)
                return stream.ReadSInt32 ();
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
            
            if (IsAClassType(type))
            {
                if (client == null)
                    throw new ArgumentException("Client not passed when decoding remote object");

                throw new NotImplementedException();
                //var id = stream.ReadUInt64(); TODO sort this out when we have a base class for remote types
                //return id == 0 ? null : (RemoteObject)Activator.CreateInstance(type, client, id);
            }

            if (IsATupleType(type))
                return DecodeTuple(stream, type, client);
            if (IsAListType(type))
                return DecodeList(stream, type, client);
            if (IsASetType(type))
                return DecodeSet(stream, type, client);
            if (IsADictionaryType(type))
                return DecodeDictionary(stream, type, client);
            if (IsAMessageType(type))
            {
                var message = (IMessage)(Activator.CreateInstance(type)
                    ?? throw new CodecException("Unable to determine message type"));
                message.MergeFrom(stream);
                return message;
            }

            //if (type != typeof(Event)) TODO sort this when we have a base class for remote types
            //    throw new ArgumentException(type + " is not a serializable type");
            
            var @event = new Schema.Event();
            @event.MergeFrom(stream);
            return null; // return new Event((Connection)client, @event); TODO sort this - presumably needs an event type to exist in the public API
        }

        private static object DecodeTuple (CodedInputStream stream, Type type, IConnection client)
        {
            var encodedTuple = ParseEncodedStream(Schema.Tuple.Parser, stream);
            var genericArgs = type.GetGenericArguments ();
            var genericType = Type.GetType ("System.Tuple`" + genericArgs.Length);
            if (genericType == null)
                throw new CodecException($"Unable to find tuple type with {genericArgs.Length} generic arguments");
            
            var values = new object[genericArgs.Length];
            for (var i = 0; i < genericArgs.Length; i++) 
            {
                var item = encodedTuple.Items [i];
                values [i] = Decode (item, genericArgs [i], client);
            }

            var constructor = GetGenericConstructor(type, genericType, false);
            var tuple = constructor.Invoke(values);
            return tuple;
        }

        private static object DecodeList (CodedInputStream stream, Type type, IConnection client)
        {
            var constructor = GetGenericConstructor(type, typeof(List<>), true);
            var encodedList = ParseEncodedStream(Schema.List.Parser, stream);
            var itemType = type.GetGenericArguments().Single();
            
            var list = (IList)constructor
                .Invoke (null);
            
            foreach (var item in encodedList.Items)
                list.Add (Decode (item, itemType, client));
            return list;
        }

        private static object DecodeSet (CodedInputStream stream, Type type, IConnection client)
        {
            var encodedSet = ParseEncodedStream(Schema.Set.Parser, stream);
            var constructor = GetGenericConstructor(type, typeof(HashSet<>), true);
            
            var set = (IEnumerable)constructor.Invoke(null);
            var addMethod = type.GetMethod("Add") 
                            ?? throw new CodecException("Unable to find add method on HashSet");
            
            foreach (var item in encodedSet.Items) 
            {
                var decodedItem = Decode (item, type.GetGenericArguments().Single(), client);
                addMethod.Invoke(set, [decodedItem]);
            }
            
            return set;
        }

        static object DecodeDictionary (CodedInputStream stream, Type type, IConnection client)
        {
            var encodedDictionary = ParseEncodedStream(Schema.Dictionary.Parser, stream);
            var constructor = GetGenericConstructor(type, typeof(Dictionary<,>), true);
            
            var dictionary = (IDictionary)constructor.Invoke(null);
            
            foreach (var entry in encodedDictionary.Entries) 
            {
                var key = Decode (entry.Key, type.GetGenericArguments () [0], client);
                var value = Decode (entry.Value, type.GetGenericArguments () [1], client);
                dictionary [key] = value;
            }
            
            return dictionary;
        }

        private static bool IsAGenericType (Type type, Type genericType)
        {
            var t = type;
            while (!ReferenceEquals (t, null))
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == genericType)
                    return true;
                
                if (t.GetInterfaces().Any(intType => IsAGenericType (intType, genericType)))
                    return true;
                
                t = t.BaseType;
            }
            
            return false;
        }

        private static bool IsAClassType (Type type)
        {
            // TODO need to implement this by determining what the base class of remote objects is going to be
            throw new NotImplementedException();
        }

        private static bool IsATupleType (Type type)
        {
            return
                IsAGenericType (type, typeof(Tuple<>)) ||
                IsAGenericType (type, typeof(Tuple<,>)) ||
                IsAGenericType (type, typeof(Tuple<,,>)) ||
                IsAGenericType (type, typeof(Tuple<,,,>)) ||
                IsAGenericType (type, typeof(Tuple<,,,,>)) ||
                IsAGenericType (type, typeof(Tuple<,,,,,>)) ||
                IsAGenericType (type, typeof(Tuple<,,,,,,>)) ||
                IsAGenericType (type, typeof(Tuple<,,,,,,,>));
        }

        private static bool IsACollectionType (Type type)
        {
            return IsATupleType (type) || IsAListType (type) || IsASetType (type) || IsADictionaryType (type);
        }

        private static bool IsAListType (Type type)
        {
            return IsAGenericType (type, typeof(IList<>));
        }

        private static bool IsASetType (Type type)
        {
            return IsAGenericType (type, typeof(ISet<>));
        }

        private static bool IsADictionaryType (Type type)
        {
            return IsAGenericType (type, typeof(IDictionary<,>));
        }

        private static bool IsAMessageType (Type type)
        {
            return typeof(IMessage).IsAssignableFrom (type);
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

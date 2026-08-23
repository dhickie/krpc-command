using System.Collections;
using System.Runtime.CompilerServices;
using kRPC.Client.Boost.Connection;
using MathNet.Spatial.Euclidean;

namespace kRPC.Client.Boost.IntegrationTests.Server;

/// <summary>
/// Provides the ability to convert client specific objects, like Vectors and Quaternions, into their server side
/// equivalent types.
/// </summary>
public static class ClientObjectConverter
{
    /// <summary>
    /// Converts a client side object into its server side equivalent.
    /// For example a Vector3D to a Tuple&lt;double,double,double&gt;.
    /// </summary>
    /// <param name="clientObject">The object to convert</param>
    /// <returns>The converted object.</returns>
    public static object? ConvertClientObject(object? clientObject)
    {
        if (clientObject == null)
            return clientObject;
        
        if (Codec.IsACollectionType(clientObject.GetType()))
        {
            return ConvertClientCollectionObject(clientObject);
        }
        
        if (clientObject?.GetType() == typeof(Vector3D))
        {
            var vec = (Vector3D)clientObject;
            return new Tuple<double, double, double>(vec.X, vec.Y, vec.Z);
        }

        if (clientObject?.GetType() == typeof(Quaternion))
        {
            var quat = (Quaternion)clientObject;
            return new Tuple<double, double, double, double>(quat.Real, quat.ImagX, quat.ImagY, quat.ImagZ);
        }

        return clientObject;
    }
    
    private static object ConvertClientCollectionObject(object clientObject)
    {
        var clientObjectType = clientObject.GetType();
        var convertedType = ConvertClientType(clientObjectType);

        if (convertedType == clientObjectType)
            return clientObject;

        if (Codec.IsAnArrayType(clientObjectType) || Codec.IsAListType(clientObjectType))
            return ConvertClientArrayOrListObject(clientObject, convertedType);
        if (Codec.IsATupleType(clientObjectType))
            return ConvertClientTupleObject(clientObject, convertedType);
        if (Codec.IsADictionaryType(clientObjectType))
            return ConvertClientDictionaryObject(clientObject, convertedType);
        if (Codec.IsASetType(clientObjectType))
            return ConvertClientSetObject(clientObject, convertedType);

        throw new ArgumentException("Unsupported object type", nameof(clientObject));
    }

    private static object ConvertClientArrayOrListObject(object clientObject, Type convertedType)
    {
        var arrayClientObject = (IList)clientObject;
        var itemCount = arrayClientObject.Count;
        var constructor = convertedType.GetConstructor([typeof(int)]);
        
        if (constructor == null) 
            throw new InvalidOperationException(
                $"Unable to find constructor for type {convertedType.Name}");
        var serverObject = (IList)constructor.Invoke([itemCount]);

        if (itemCount == 0) // Return early if there are no items to add to the array
            return serverObject;

        for (var i = 0; i < itemCount; i++)
        {
            serverObject[i] = ConvertClientObject(arrayClientObject[i]);
        }
        
        return serverObject;
    }

    private static object ConvertClientTupleObject(object clientObject, Type convertedType)
    {
        var typeArgs = convertedType.GetGenericArguments();
        var numArgs = typeArgs.Length;
        var constructor = convertedType.GetConstructor(typeArgs)
            ?? throw new InvalidOperationException($"Failed to find constructor for type {convertedType.Name}");

        var tupleClientObject = (ITuple)clientObject;
        var convertedElements = new object?[numArgs];
        for (var i = 0; i < numArgs; i++)
        {
            convertedElements[i] = ConvertClientObject(tupleClientObject[i]);
        }

        return constructor.Invoke(convertedElements);
    }
    
    private static object ConvertClientDictionaryObject(object clientObject, Type convertedType)
    {
        var typeArgs = convertedType.GetGenericArguments();
        var constructor = convertedType.GetConstructor(typeArgs)
            ?? throw new InvalidOperationException($"Failed to find constructor for type {convertedType.Name}");

        var serverObject = (IDictionary)constructor.Invoke(null);
        var dictionaryClientObject = (IDictionary)clientObject;

        foreach (var key in dictionaryClientObject.Keys)
        {
            var convertedKey = ConvertClientObject(key)
                ?? throw new InvalidOperationException($"Dictionary object has null key");
            var convertedValue = ConvertClientObject(dictionaryClientObject[key]);
            
            serverObject.Add(convertedKey, convertedValue);
        }
        
        return serverObject;
    }

    private static object ConvertClientSetObject(object clientObject, Type convertedType)
    {
        var constructor = convertedType.GetConstructor(Type.EmptyTypes)
            ?? throw new InvalidOperationException($"Failed to find constructor for type {convertedType.Name}");

        var serverObject = constructor.Invoke(null);
        var addMethod = convertedType.GetMethod("Add")
            ?? throw new InvalidOperationException($"Failed to find Add method on HashSet");

        var enumerableClientObject = (IEnumerable)clientObject;
        foreach (var item in enumerableClientObject)
        {
            var convertedItem = ConvertClientObject(item);
            addMethod.Invoke(serverObject, [convertedItem]);
        }
        
        return serverObject;
    }

    private static Type ConvertClientType(Type clientType)
    {
        if (Codec.IsACollectionType(clientType))
            return ConvertClientCollectionType(clientType);
        else if (clientType == typeof(Vector3D))
            return typeof(Tuple<double, double, double, double>);
        else if (clientType == typeof(Quaternion))
            return typeof(Tuple<double, double, double, double>);

        return clientType;
    }

    private static Type ConvertClientCollectionType(Type clientType)
    {
        if (Codec.IsAnArrayType(clientType))
            return ConvertClientArrayType(clientType);
        if (Codec.IsADictionaryType(clientType))
            return ConvertClientGenericType(clientType, typeof(Dictionary<,>));
        if (Codec.IsAListType(clientType))
            return ConvertClientGenericType(clientType, typeof(List<>));
        if (Codec.IsASetType(clientType))
            return ConvertClientGenericType(clientType, typeof(HashSet<>));
        if (Codec.IsATupleType(clientType))
            return ConvertClientTupleType(clientType);

        throw new InvalidOperationException($"{clientType.Name} is not a supported collection type");
    }

    private static Type ConvertClientArrayType(Type clientType)
    {
        var elementType = clientType.GetElementType() 
                          ?? throw new ArgumentException($"{nameof(clientType)} is not an array type");
        var newElementType = ConvertClientType(elementType);
        return newElementType.MakeArrayType();
    }

    private static Type ConvertClientTupleType(Type clientType)
    {
        var typeArgs = clientType.GenericTypeArguments;
        var genericType = typeArgs.Length switch
        {
            2 => typeof(Tuple<,>),
            3 => typeof(Tuple<,,>),
            4 => typeof(Tuple<,,,>),
            _ => throw new NotImplementedException("More generic Tuple types need to be implemented.")
        };
        
        return ConvertClientGenericType(clientType, genericType);
    }

    private static Type ConvertClientGenericType(Type clientType, Type genericType)
    {
        var typeArgs = clientType.GenericTypeArguments;
        var typeChanged = false;
        for (var i = 0; i < typeArgs.Length; i++)
        {
            var originalArg = typeArgs[i];
            var newArg = ConvertClientType(originalArg);
            if (newArg != originalArg)
            {
                typeChanged = true;
                typeArgs[i] = ConvertClientType(typeArgs[i]);
            }
        }
        
        if (!typeChanged)
            return clientType;

        var specificType = genericType.MakeGenericType(typeArgs);
        return specificType;
    }
}
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;

namespace kRPC.Client.Boost.IntegrationTests.AutoFixture;

public sealed class ServiceObjectCustomisation : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Insert(
            0,
            new ServiceObjectBuilder());
    }

    internal sealed class ServiceObjectBuilder : ISpecimenBuilder
    {
        private static IConnectionMultiplexer? _connection;
        
        public static void SetConnection(IConnectionMultiplexer connection)
        {
            _connection = connection;
        }

        public object Create(
            object request,
            ISpecimenContext context)
        {
            if (request is not Type requestedType)
                return new NoSpecimen();

            if (typeof(RemoteObject).IsAssignableFrom(requestedType))
                return CreateServiceObject(requestedType, context, true);
            
            if (typeof(ServiceObject).IsAssignableFrom(requestedType))
                return CreateServiceObject(requestedType, context, false);

            return new NoSpecimen();
        }

        private object CreateServiceObject(Type requestedType, ISpecimenContext context, bool isRemoteObject)
        {
            if (_connection == null)
                throw new InvalidOperationException("Cannot create service objects when no connection has been set");
            
            object?[]? args;
            if (isRemoteObject)
            {
                var id = Create<ulong>(context);
                args = [_connection, id];
            }
            else
            {
                args = [_connection];
            }
        
            var instance = Activator.CreateInstance(
                requestedType,
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                args,
                null);

            return instance ?? throw new InvalidOperationException($"Unable to resolve type {requestedType.Name}");
        }

        private object Create<T>(ISpecimenContext context)
        {
            return context.Resolve(typeof(T))
                ?? throw new InvalidOperationException($"Unable to resolve type {typeof(T).Name}");
        }
    }
}
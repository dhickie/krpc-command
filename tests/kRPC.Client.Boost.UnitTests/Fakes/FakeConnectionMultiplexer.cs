using System.Linq.Expressions;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services.KRPC;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;
using kRPC.Client.Boost.Services.SpaceCenter;

namespace kRPC.Client.Boost.UnitTests.Fakes;

public class FakeConnectionMultiplexer : IConnectionMultiplexer
{
    public KRPC KRPC { get; }
    public SpaceCenter SpaceCenter { get; }
    
    public RemoteStream AddStream<T>(Expression<Func<T>> expression, bool start)
    {
        throw new NotImplementedException();
    }

    public Task<RemoteStream> AddStreamAsync<T>(Expression<Func<T>> expression, bool start)
    {
        throw new NotImplementedException();
    }

    public void RemoveStream(ulong streamId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveStreamAsync(ulong streamId)
    {
        throw new NotImplementedException();
    }

    public void Invoke(string service, string procedure, object?[]? arguments = null)
    {
        throw new NotImplementedException();
    }

    public TResponse? Invoke<TResponse>(string service, string procedure, object?[]? arguments = null)
    {
        throw new NotImplementedException();
    }

    public Task InvokeAsync(string service, string procedure, object?[]? arguments = null)
    {
        throw new NotImplementedException();
    }

    public Task<TResponse?> InvokeAsync<TResponse>(string service, string procedure, object?[]? arguments = null)
    {
        throw new NotImplementedException();
    }
}
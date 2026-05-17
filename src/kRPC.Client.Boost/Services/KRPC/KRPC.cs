using System.Linq.Expressions;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;

namespace kRPC.Client.Boost.Services.KRPC;

public class KRPC(ConnectionMultiplexer connection)
{
    internal RemoteStream AddStream<T>(Expression<Func<T>> expression, bool start)
    {
        return connection.Invoke<RemoteStream>("KRPC", "AddStream", [expression, start]);
    }

    internal async Task<RemoteStream> AddStreamAsync<T>(Expression<Func<T>> expression, bool start)
    {
        return await connection.InvokeAsync<RemoteStream>("KRPC", "AddStream", [expression, start]);
    }
}
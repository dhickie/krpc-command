using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.KRPC.RemoteObjects;

public class RemoteStream(long id, ConnectionMultiplexer connection) : RemoteObject(id, connection)
{
    public void Remove()
    {
        Connection.Invoke("KRPC", "RemoveStream", [Id]);
    }

    public async Task RemoveAsync()
    {
        await Connection.InvokeAsync("KRPC", "RemoveStream", [Id]);
    }
}
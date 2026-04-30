using KRPC.Client.Services.MechJeb;

namespace KrpcCommand.Extensions;

public static class MechJebExtensions
{
    public static async Task ExecuteNodeAsync(this NodeExecutor exec, CancellationToken cancellationToken)
    {
        exec.Autowarp = true;
        exec.ExecuteOneNode();

        // Poll until execution completes
        while (exec.Enabled)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                exec.Abort();
                cancellationToken.ThrowIfCancellationRequested();
            }
            
            await Task.Delay(1000, CancellationToken.None);
        }
    }
    
    public static async Task EnsureApiReadyAsync(this Service mj, CancellationToken cancellationToken)
    {
        if (!mj.APIReady)
        {
            while (!mj.APIReady)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(500, cancellationToken);
            }
        }
    }
}
namespace kRPC.Client.Boost.UnitTests.Helpers;

/// <summary>
/// Contains methods for helping with simulating race conditions for testing
/// </summary>
public class SyncHelper
{
    /// <summary>
    /// Executes two actions simultaneously on different threads.
    /// </summary>
    /// <param name="actionA">The first action to execute</param>
    /// <param name="actionB">The second action to execute</param>
    public void ExecuteSimultaneously(Action actionA, Action actionB)
    {
        var startEvent = new ManualResetEventSlim(false);
        var endEventA = new ManualResetEventSlim(false);
        var endEventB = new ManualResetEventSlim(false);
        
        DoAction(startEvent, endEventA, actionA);
        DoAction(startEvent, endEventB, actionB);

        startEvent.Set();
        endEventA.Wait();
        endEventB.Wait();
    }

    private static void DoAction(ManualResetEventSlim startEvent, ManualResetEventSlim endEvent, Action action)
    {
        _ = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            startEvent.Wait();
            action();
            endEvent.Set();
        });
    }
}
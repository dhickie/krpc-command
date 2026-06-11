namespace kRPC.Client.Boost.Exceptions;

/// <summary>
/// Used to kill the polling loop in PollingConnection from inside a synchronisation block
/// </summary>
internal class LoopKillException : Exception
{
    
}
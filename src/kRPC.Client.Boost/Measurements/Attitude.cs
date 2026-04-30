namespace kRPC.Client.Boost.Measurements;

public class Attitude<T>(T pitch, T roll, T yaw)
{
    public T Pitch { get; } = pitch;
    public T Roll { get; } = roll;
    public T Yaw { get; } = yaw;
}
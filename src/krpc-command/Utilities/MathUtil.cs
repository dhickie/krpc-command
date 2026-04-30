namespace KrpcCommand.Utilities;

public static class MathUtil
{
    public static double RadToDeg(double rad)
    {
        return rad * 180 / Math.PI;
    }

    public static double DegToRad(double deg)
    {
        return deg * Math.PI / 180;
    }
    
    public static double Wrap(double value, double min, double max)
    {
        if (max <= min)
        {
            throw new ArgumentException("max must be greater than min");
        }

        var span = max - min;
        return ((value - min) % span + span) % span + min;
    }
}
#region License
// The below class provides an implementation of Izzo's Lambert solving algorithm,
// adapted from the implementation available in TheWand3rer/Universe to remove the
// dependence on Unity packages, and use more idiomatic C#.
//
// The license from the original implementation is included below.
//
// MIT License
// 
// Copyright (c) 2025 TheWand3rer
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Utilities;

public class IzzoLambertSolver(
    bool lowPath = true,
    bool prograde = true,
    double tolerance = 1e-8,
    int maxIterations = 100,
    int revolutions = 0)
{
    private readonly Vector3D _zeroVector = new(0, 0, 0);

    /// <summary>
    /// Solves the Lambert problem using the Izzo algorithm. Assumes that there is a solution, and throw an
    /// exception if one can't be found.
    /// </summary>
    /// <param name="gravitationalParameter">Gravitational constant of main attractor (m^3 / s^2).</param>
    /// <param name="initialPosition">Initial position (m).</param>
    /// <param name="finalPosition">Final position (m).</param>
    /// <param name="timeOfFlight">Time of flight (timespan).</param>
    /// <returns></returns>
    public (Vector3D v1, Vector3D v2) Solve(double gravitationalParameter,
        Vector3D initialPosition,
        Vector3D finalPosition,
        TimeSpan timeOfFlight)
    {
        if (TrySolve(gravitationalParameter, initialPosition, finalPosition, timeOfFlight, out var solution))
        {
            return solution;
        }
        
        throw new InvalidOperationException("No solution could be found for the provided flight parameters");
    }
    
    /// <summary>
    ///     Solves the Lambert problem using the Izzo Algorithm.
    /// </summary>
    /// <param name="gravitationalParameter">Gravitational constant of main attractor (m^3 / s^2).</param>
    /// <param name="initialPosition">Initial position (m).</param>
    /// <param name="finalPosition">Final position (m).</param>
    /// <param name="timeOfFlight">Time of flight (timespan).</param>
    /// <param name="solution">The solution if the solution was successfully found</param>
    /// <returns>Whether the solution was successfully found</returns>
    public bool TrySolve(
        double gravitationalParameter, 
        Vector3D initialPosition, 
        Vector3D finalPosition, 
        TimeSpan timeOfFlight,
        out (Vector3D v1, Vector3D v2) solution)
    {
        var k = gravitationalParameter;
        var r1 = initialPosition;
        var r2 = finalPosition;
        var tof = timeOfFlight.TotalSeconds;

        Validate(tof > 0, nameof(timeOfFlight));
        Validate(k > 0, nameof(gravitationalParameter));
        Validate(tolerance > 0, nameof(tolerance));
        if (r1.CrossProduct(r2) == _zeroVector)
            throw new ArgumentException("Lambert solution cannot be computed for collinear vectors");

        var c = r2 - r1;
        var cN = c.Length;
        var r1N = r1.Length;
        var r2N = r2.Length;

        // Semiperimeter
        var s = (r1N + r2N + cN) * 0.5;

        // Versors
        var ir1 = r1.Normalize();
        var ir2 = r2.Normalize();
        var ih = ir1.CrossProduct(ir2);

        // Geometry of the problem
        var ll = Math.Sqrt(1 - Math.Min(1.0, cN / s));

        // Compute the fundamental tangential directions
        UnitVector3D it1, it2;
        if (ih.Z < 0)
        {
            ll  = -ll;
            it1 = ir1.CrossProduct(ih);
            it2 = ir2.CrossProduct(ih);
        }
        else
        {
            it1 = ih.CrossProduct(ir1);
            it2 = ih.CrossProduct(ir2);
        }
        
        (ll, it1, it2) = prograde ? (ll, it1, it2) : (-ll, it1.Negate(), it2.Negate());

        // Non-dimensional time of flight
        var T = Math.Sqrt(2 * k / Math.Pow(s, 3)) * tof;

        if (!TryFindXY(ll, T, revolutions, out (double x, double y) xy))
        {
            solution = (_zeroVector, _zeroVector);
            return false;
        }

        // Reconstruct
        var gamma = Math.Sqrt(k * s / 2);
        var rho = (r1N - r2N) / cN;
        var sigma = Math.Sqrt(1 - Math.Pow(rho, 2));

        var (vR1, vR2, vT1, vT2) = Reconstruct(xy.x, xy.y, r1N, r2N, ll, gamma, rho, sigma);

        // Solve for the initial and final velocity
        var v1 = vR1 * (r1 / r1N) + vT1 * it1;
        var v2 = vR2 * (r2 / r2N) + vT2 * it2;

        solution = (v1, v2);
        return true;
    }

    /// <summary>
    ///     Compute minimum T.
    /// </summary>
    private bool TryComputeTMin(double ll, int m, out double tMin)
    {
        if (Math.Abs(ll - 1) < tolerance)
        {
            tMin = TofEquation(0, 0, ll, m);
        }
        else
        {
            if (m == 0)
            {
                tMin = 0;
            }
            else
            {
                // Set xi > 0 to avoid problems at ll = -1
                const double xi = 0.1;
                var ti = TofEquation(xi, 0.0, ll, m);

                if (!TryHalley(xi, ti, ll, out var xTmin))
                {
                    tMin = 0;
                    return false;
                }
                tMin = TofEquation(xTmin, 0, ll, m);
            }
        }

        return true;
    }

    private static double ComputeY(double x, double ll)
    {
        return Math.Sqrt(1 - Math.Pow(ll, 2) * (1 - x * x));
    }

    /// <summary>
    ///     Computes psi.
    ///     The auxiliary angle psi is computed using Eq.(17) by the appropriate inverse function.
    /// </summary>
    /// <returns>The angle psi.</returns>
    private static double ComputePsi(double x, double y, double ll)
    {
        return x switch
        {
            >= -1 and < 1 => Math.Acos(x * y + ll * (1 - Math.Pow(x, 2))),
            > 1 => Math.Sinh(y - x * ll) * Math.Sqrt(Math.Pow(x, 2) - 1),
            _ => 0 // Parabolic motion
        };
    }

    /// <summary>
    ///     Computes all x, y for given number of revolutions.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    private bool TryFindXY(double ll, double T, int m, out (double, double) xy)
    {
        // For abs(ll) == 1 the derivative is not continuous
        Validate(Math.Abs(ll) < 1, nameof(ll));
        Validate(T > 0, nameof(T)); // Mistake in the original paper
        var mMax = (int)Math.Floor(T / Math.PI);
        var t00 = Math.Acos(ll) + ll * Math.Sqrt(1 - Math.Pow(ll, 2)); // T_xM

        // Refine maximum number of revolutions if necessary
        if (T < t00 + mMax * Math.PI && mMax > 0)
        {
            if (!TryComputeTMin(ll, mMax, out var tMin))
            {
                xy = (0, 0);
                return false;
            }
            if (T < tMin)
                mMax -= 1;
        }

        // Check if a feasible solution exist for the given number of revolutions
        // This departs from the original paper in that we do not compute all solutions
        if (m > mMax)
        {
            xy = (0, 0);
            return false;
        }

        var x0 = InitialGuess(T, ll, m);

        // Start Householder iterations from x_0 and find x, y
        if (!TryHouseholder(x0, T, ll, m, out var x))
        {
            xy = (0, 0);
            return false;
        }
        var y = ComputeY(x, ll);
        
        xy = (x, y);
        return true;
    }

    /// <summary>
    ///     Find a minimum of time of flight equation using the Halley method.
    /// </summary>
    private bool TryHalley(double p0, double t0, double ll, out double tofMin)
    {
        for (var i = 0; i < maxIterations; i++)
        {
            var y = ComputeY(p0, ll);
            var fDer = TofEquationP(p0, y, t0, ll);
            var fDer2 = TofEquationP2(p0, y, t0, fDer, ll);
            if (Math.Abs(fDer2) < tolerance)
            {
                tofMin = 0;
                return false;
            }
            var fDer3 = TofEquationP3(p0, y, t0, fDer, fDer2, ll);

            // Halley step (cubic)
            var p = p0 - 2 * fDer * fDer2 / (2 * Math.Pow(fDer2, 2) - fDer * fDer3);

            if (Math.Abs(p - p0) < tolerance)
            {
                tofMin = p;
                return true;
            }
            
            p0 = p;
        }

        tofMin = 0;
        return false;
    }

    /// <summary>
    ///     Find a zero of time of flight equation using the Householder method.
    /// </summary>
    private bool TryHouseholder(double p0, double t0, double ll, int m, out double p)
    {
        for (var i = 0; i < maxIterations; i++)
        {
            var y = ComputeY(p0, ll);
            var fVal = TofEquationY(p0, y, t0, ll, m);
            var T = fVal + t0;
            var fDer = TofEquationP(p0, y, T, ll);
            var fDer2 = TofEquationP2(p0, y, T, fDer, ll);
            var fDer3 = TofEquationP3(p0, y, T, fDer, fDer2, ll);

            // Householder step (quartic)
            p = p0 - fVal * ((Math.Pow(fDer, 2) - fVal * fDer2 / 2)
                                  / (fDer * (Math.Pow(fDer, 2) - fVal * fDer2) + fDer3 * Math.Pow(fVal, 2) / 6));

            if (Math.Abs(p - p0) < tolerance)
                return true;
            p0 = p;
        }

        p = 0;
        return false;
    }

    private static double Hypergeometric2F1B(double x)
    {
        const double rTol = 1e8;
        if (x >= 0)
            return double.PositiveInfinity;
        var res = 1.0;
        var term = 1.0;
        double i = 0;
        while (true)
        {
            term = term * (3 + i) * (1 + i) / (5 / 2d + i) * x / (i + 1);
            var resOld = res;
            res += term;
            if (Math.Abs(resOld - res) < rTol)
                return res;
            i += 1;
        }
    }

    private double InitialGuess(double T, double ll, int m)
    {
        double x0;
        if (m == 0)
        {
            // Single revolution
            // Equation 19
            var t0 = Math.Acos(ll) + ll * Math.Sqrt(1 - Math.Pow(ll, 2)) + m * Math.PI;
            // Equation 21
            var t1 = 2 * (1 - Math.Pow(ll, 3)) / 3;

            if (T >= t0)
                x0 = Math.Pow(t0 / T, 2 / 3d) - 1;
            else if (T < t1)
                x0 = 5 / 2d * t1 / T * (t1 - T) / (1 - Math.Pow(ll, 5)) + 1;
            else
            {
                // This is the real condition, which is not exactly equivalent
                // elif T_1 < T < T_0
                // Corrected initial guess,
                // piecewise equation right after expression (30) in the original paper is incorrect
                // See https://github.com/hapsira/hapsira/issues/1362
                x0 = Math.Exp(Math.Log(2) * Math.Log(T / t0) / Math.Log(t1 / t0)) - 1;
            }

            return x0;
        }

        // Multiple revolution
        var x0L = (Math.Pow((m * Math.PI + Math.PI) / (8 * T), 2 / 3d) - 1) / (Math.Pow((m * Math.PI + Math.PI) / (8 * T), 2 / 3d) + 1);
        var x0R = (Math.Pow((8 * T) / (m * Math.PI), 2 / 3d) - 1) / (Math.Pow((8 * T) / (m * Math.PI), 2 / 3d) + 1);

        // Select one of the solutions according to desired type of path
        x0 = lowPath ? Math.Max(x0L, x0R) : Math.Min(x0L, x0R);

        return x0;
    }

    /// <summary>
    ///     Reconstruct solution velocity vectors.
    /// </summary>
    private static (double, double, double, double) Reconstruct(
        double x, double y, double r1, double r2, double ll, double gamma, double rho, double sigma)
    {
        var vR1 = gamma * ((ll * y - x) - rho * (ll * y + x)) / r1;
        var vR2 = -gamma * ((ll * y - x) + rho * (ll * y + x)) / r2;
        var vT1 = gamma * sigma * (y + ll * x) / r1;
        var vT2 = gamma * sigma * (y + ll * x) / r2;

        return (vR1, vR2, vT1, vT2);
    }

    private double TofEquation(double x, double t0, double ll, int m)
    {
        return TofEquationY(x, ComputeY(x, ll), t0, ll, m);
    }

    private static double TofEquationP(double x, double y, double T, double ll)
    {
        return (3 * T * x - 2 + 2 * Math.Pow(ll, 3) * x / y) / (1 - Math.Pow(x, 2));
    }

    private static double TofEquationP2(double x, double y, double T, double dT, double ll)
    {
        return (3 * T + 5 * x * dT + 2 * (1 - Math.Pow(ll, 2)) * Math.Pow(ll, 3) / Math.Pow(y, 3)) / (1 - Math.Pow(x, 2));
    }

    private static double TofEquationP3(double x, double y, double _, double dT, double ddT, double ll)
    {
        return (7 * x * ddT + 8 * dT - 6 * (1 - Math.Pow(ll, 2)) * Math.Pow(ll, 5) * x / Math.Pow(y, 5)) / (1 - Math.Pow(x, 2));
    }

    /// <summary>
    ///     Time of flight equation with externally calculated y.
    /// </summary>
    /// <returns></returns>
    private double TofEquationY(double x, double y, double t0, double ll, int m)
    {
        double t;
        if (Math.Abs(ll) < tolerance && x > Math.Sqrt(0.6) && x < Math.Sqrt(1.4))
        {
            var eta = y - ll * x;
            var s1 = (1 - ll - x * eta) * 0.5;
            var q = 4 / 3d * Hypergeometric2F1B(s1);
            t = (Math.Pow(eta, 3) * q + 4 * ll * eta) * 0.5;
        }
        else
        {
            var psi = ComputePsi(x, y, ll);

            var xT0 = (psi + m * Math.PI) / Math.Sqrt(Math.Abs(1 - Math.Pow(x, 2)));
            t = (xT0 - x + ll * y) / (1 - Math.Pow(x, 2));
        }

        return t - t0;
    }

    private static void Validate(bool valid, string parameterName)
    {
        if (!valid)
        {
            throw new ArgumentException($"Provided {parameterName} did not have a valid value");
        }
    }
}
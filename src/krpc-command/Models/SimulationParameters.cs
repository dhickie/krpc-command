using KRPC.Client.Services.SpaceCenter;

namespace KrpcCommand.Models;

public class SimulationParameters
{
    public double BodyGravitationalParameter { get; set; }
    public double FuelBurnRate { get; set; } // kg per second
    public double Thrust { get; set; } // Ship's max thrust in Newtons
    public double InitialMass { get; set; } // The initial mass of the ship in kg
    
    private const double KerbinGravity = 9.81;
    
    /// <summary>
    /// Creates an object defining the parameters that govern a simulation of a burn
    /// </summary>
    /// <param name="vessel">The vessel that will be performing the burn</param>
    public SimulationParameters(Vessel vessel)
    {
        BodyGravitationalParameter = vessel.Orbit.Body.GravitationalParameter;

        FuelBurnRate = 0;
        Thrust = 0;
        var engines = vessel.Parts.Engines.Where(x => x.Active);
        foreach (var engine in engines)
        {
            var isp = engine.SpecificImpulse;
            var thrust = engine.Thrust;
            
            FuelBurnRate += thrust / (isp * KerbinGravity);
            Thrust += thrust;
        }

        InitialMass = vessel.Mass;
    }
}
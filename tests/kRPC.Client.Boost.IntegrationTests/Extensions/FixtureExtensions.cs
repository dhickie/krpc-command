using AutoFixture;
using AutoFixture.Kernel;

namespace kRPC.Client.Boost.IntegrationTests.Extensions;

/// <summary>
/// Helper methods for creating test data using AutoFixture.
/// </summary>
public static class FixtureExtensions
{
    /// <summary>
    /// Creates a random value of the provided runtime type.
    /// </summary>
    /// <param name="fixture">The Fixture instance to use</param>
    /// <param name="type">The type to create</param>
    /// <returns>A random value of the requested type</returns>
    public static object Create(this Fixture fixture, Type type)
    {
        return new SpecimenContext(fixture).Resolve(type);
    }
}
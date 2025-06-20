using Xunit;

namespace AdvancedTests.Ecommerce.UnitTests.Domain;

public class LifeCycleTestFixture : IDisposable
{
    public LifeCycleTestFixture()
    {
        Console.WriteLine("Fixture Setup.");
    }

    public void Dispose()
    {
        Console.WriteLine("Fixture Cleanup.");
    }
}

[CollectionDefinition("LifeCycleTestCollection")]
public class LifeCycleTestFixtureCollection : ICollectionFixture<LifeCycleTestFixture>;
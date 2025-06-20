using Xunit;

namespace AdvancedTests.Ecommerce.UnitTests.Domain;

[CollectionDefinition("LifecycleTestCollection")]
public class LifecycleTest : IClassFixture<LifeCycleTestFixture>, IDisposable
{
    public LifecycleTest()
    {
        Console.WriteLine("Test Setup.");
    }

    [Fact]
    public void Test1()
    {
        Console.WriteLine("Running Test 1.");
    }

    [Fact]
    public void Test2()
    {
        Console.WriteLine("Running Test 2.");
    }

    public void Dispose()
    {
        Console.WriteLine("Test Cleanup.");
    }
}
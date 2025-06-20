using Xunit;

namespace AdvancedTests.Ecommerce.UnitTests.Domain;

[CollectionDefinition("LifecycleTestCollection")]
public class LifecycleTestCollec : IDisposable
{
    public LifecycleTestCollec()
    {
        Console.WriteLine("Test Collection Setup.");
    }

    [Fact]
    public void Test1()
    {
        Console.WriteLine("Running Test Collection 1.");
    }

    [Fact]
    public void Test2()
    {
        Console.WriteLine("Running Test Collection 2.");
    }

    public void Dispose()
    {
        Console.WriteLine("Test Collection Cleanup.");
    }
}
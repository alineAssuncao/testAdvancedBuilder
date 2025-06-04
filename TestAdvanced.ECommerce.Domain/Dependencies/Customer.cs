using Ardalis.GuardClauses;

namespace TestAdvanced.ECommerce.Domain;

public class Customer
{
    public Customer(int id, string name)
    {
        Id = Guard.Against.NegativeOrZero(id);
        Name = Guard.Against.NullOrWhiteSpace(name);
    }
    
    public int Id { get; }
    public string Name { get; }
}
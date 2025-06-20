using AdvancedTests.Ecommerce.Domain.Entities;
using Bogus;

namespace AdvancedTests.Ecommerce.UnitTests.DataBuilder;

public class CustomerDataBuilder
{
    private int _id;
    private string _name;
    private bool _isPremium;

    public CustomerDataBuilder()
    {
        var faker = new Faker("pt_BR");
        _id = faker.Random.Int(1);
        _name = faker.Person.FullName;
        _isPremium = faker.Random.Bool(0.5f); // 50% chance of being premium
    }

    public static CustomerDataBuilder APremiumCustomer()
    {
        return new CustomerDataBuilder().AsPremium();
    }

    public static CustomerDataBuilder ARegularCustomer()
    {
        return new CustomerDataBuilder().AsRegular();
    }

    public CustomerDataBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public CustomerDataBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CustomerDataBuilder AsPremium()
    {
        _isPremium = true;
        return this;
    }

    public CustomerDataBuilder AsRegular()
    {
        _isPremium = false;
        return this;
    }
    public Customer Build()
    {
        return new Customer(_id, _name, _isPremium);
    }
}
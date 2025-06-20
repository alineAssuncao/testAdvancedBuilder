using AdvancedTests.Ecommerce.Application.UseCases.CreateOrder;
using AdvancedTests.Ecommerce.Domain.Entities;
using Bogus;

namespace AdvancedTests.Ecommerce.UnitTests.DataBuilder;

public class CreateOrderInputDataBuilder
{
    private int _customerId;
    private string _street;
    private string _city;
    private string _state;
    private string _zipCode;
    private int _number;
    private IEnumerable<CreateOrderItemInput> _items;

    public const int ExistingCustomerId = 10_0000;

    public CreateOrderInputDataBuilder()
    {
        var faker = new Faker("pt_BR");
        _customerId = faker.Random.Int(1, 1000);
        _street = faker.Address.StreetAddress();
        _city = faker.Address.City();
        _state = faker.Address.StateAbbr();
        _zipCode = faker.Address.ZipCode();
        _number = faker.Random.Int(1, 1000);
        _items = new List<CreateOrderItemInput>
        {
            AnItemInput().Build(),
            AnItemInput().Build()
        };
    }

    public static CreateOrderInputDataBuilder AnItemInput() => new();

    public CreateOrderInputDataBuilder FromCustomer(int customerId)
    {
        _customerId = customerId;
        return this;
    }

    public CreateOrderInput Build()
    {
       return new CreateOrderInput(
           _customerId,
           new CreateOrderAddressInput(_street, _city, _state, _zipCode, _number),
           _items);
    }

}

 
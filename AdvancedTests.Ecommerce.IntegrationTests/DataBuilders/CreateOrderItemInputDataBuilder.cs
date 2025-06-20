using AdvancedTests.Ecommerce.Application.UseCases.CreateOrder;
using Bogus;

namespace AdvancedTests.Ecommerce.UnitTests.DataBuilder;

public class CreateOrderItemInputDataBuilder
{
    private string _name;
    private int _quantity;
    private decimal _price;

    public CreateOrderItemInputDataBuilder()
    {
        var faker = new Bogus.Faker("pt_BR");
        _name faker.Commerce.ProductName();
        _quantity = faker.Random.Int(1, 10);
        _price = decimal.Parse(faker.Commerce.Price());
    }
    
    public static CreateOrderItemInputDataBuilder AnItemInput() => new ();
    
    public CreateOrderInputDataBuilder Build()
    {
        return new CreateOrderInputDataBuilder(_name, _quantity, _price);
    }
}
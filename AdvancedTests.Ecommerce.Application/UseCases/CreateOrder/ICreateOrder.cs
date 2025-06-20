namespace AdvancedTests.Ecommerce.Application.UseCases.CreateOrder;

public interface ICreateOrder
{
    Task<CreateOrderOutput> ExecuteAsync(CreateOrderInput input);
}
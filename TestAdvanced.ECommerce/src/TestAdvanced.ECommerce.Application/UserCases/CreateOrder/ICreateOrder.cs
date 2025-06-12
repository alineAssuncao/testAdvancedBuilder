namespace TestAdvanced.ECommerce.Application.UserCases.CreateOrder;

public interface ICreateOrder
{
    Task<CreateOrderOutput> ExecuteAsync(CreateOrderInput input);
}
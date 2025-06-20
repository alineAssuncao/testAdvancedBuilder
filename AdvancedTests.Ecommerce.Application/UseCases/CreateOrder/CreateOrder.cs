using AdvancedTests.Ecommerce.Domain.Entities;
using AdvancedTests.Ecommerce.Domain.Repositories;

namespace AdvancedTests.Ecommerce.Application.UseCases.CreateOrder;

public class CreateOrder(
    ICustomerRepository customerRepository,
    IOrderRepository orderRepository) : ICreateOrder
{
    public async Task<CreateOrderOutput> ExecuteAsync(CreateOrderInput input)
    {
        var customer = await customerRepository.GetByIdAsync(input.CustomerId);
        if (customer == null)
        {
            throw new InvalidOperationException($"Customer not found.");
        }

        var order = new Order(customer, input.Address.ToAddress(),
            input.Items.Select(i => i.ToOrderItem()).ToList());
        var orderId = await orderRepository.AddAsync(order);
        
        return new CreateOrderOutput(order.Id);
    }
}
using AdvancedTests.Ecommerce.Domain.Entities;

namespace AdvancedTests.Ecommerce.Domain.Repositories;

public interface IOrderRepository
{
    Task<int> AddAsync(Order order);
}
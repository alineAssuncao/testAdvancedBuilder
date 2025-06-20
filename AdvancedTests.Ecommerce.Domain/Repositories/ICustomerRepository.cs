using AdvancedTests.Ecommerce.Domain.Entities;

namespace AdvancedTests.Ecommerce.Domain.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(int Id);
}
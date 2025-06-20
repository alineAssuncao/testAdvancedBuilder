using System.Threading.Tasks;
using TestAdvanced.ECommerce.Domain.Entities;

namespace TestAdvanced.ECommerce.Domain.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(int Id);
}
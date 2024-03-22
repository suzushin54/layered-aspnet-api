using src.Monolith.Domain.Entities;

namespace src.Monolith.Domain.RepositoryInterfaces;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetCustomers();
    Customer? GetCustomerById(Guid id);
}

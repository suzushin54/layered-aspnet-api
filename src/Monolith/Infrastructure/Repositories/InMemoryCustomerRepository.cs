using src.Monolith.Domain.Entities;
using src.Monolith.Domain.RepositoryInterfaces;

namespace src.Monolith.Infrastructure.Repositories;

public class InMemoryCustomerRepository : ICustomerRepository
{
    private static List<Customer> _customers = [];

    public InMemoryCustomerRepository()
    {
        _customers =
        [
            new Customer("John Doe", "jogndoe@example.com", "", "Gold", "", 3, DateTime.Now, null),
            new Customer("Alice Smith", "alicesmith@example.com", "", "Silver", "", 2, DateTime.Now, null),
            new Customer("Bob Brown", "bob@example.com", "", "Bronze", "", 1, DateTime.Now, null),
        ];
    }

    public IEnumerable<Customer> GetCustomers()
    {
        return _customers;
    }

    public Customer? GetCustomerById(Guid id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }
}
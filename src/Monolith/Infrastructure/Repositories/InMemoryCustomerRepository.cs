using src.Monolith.Domain.Entities;
using src.Monolith.Domain.Enums;
using src.Monolith.Domain.RepositoryInterfaces;

namespace src.Monolith.Infrastructure.Repositories;

public class InMemoryCustomerRepository : ICustomerRepository
{
    private static List<Customer> _customers = [];

    public InMemoryCustomerRepository()
    {
        _customers =
        [
            new Customer("John Doe", "jogndoe@example.com", "123 Main Street, Anytown, CA 12345, USA", CustomerRank.Platinum, "要注意客", 13, DateTime.Now, null),
            new Customer("Alice Smith", "alicesmith@example.com", "", CustomerRank.Gold, "", 2, DateTime.Now, null),
            new Customer("Bob Brown", "bob@example.com", "", CustomerRank.Platinum, "", 1, DateTime.Now, null),
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
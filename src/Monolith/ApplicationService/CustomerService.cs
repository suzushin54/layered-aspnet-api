using src.Monolith.Domain.Entities;
using src.Monolith.Domain.RepositoryInterfaces;

namespace src.Monolith.ApplicationService;

public interface ICustomerService
{
    IEnumerable<Customer> GetCustomers();
    Customer? GetCustomerById(Guid id);
}

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public IEnumerable<Customer> GetCustomers()
    {
        return _customerRepository.GetCustomers();
    }

    public Customer? GetCustomerById(Guid id)
    {
        return _customerRepository.GetCustomerById(id);
    }
}
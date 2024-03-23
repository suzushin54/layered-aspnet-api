using src.Monolith.ApplicationService.QueryServiceInterface;
using src.Monolith.ApplicationService.ReadModel;
using src.Monolith.Domain.Entities;
using src.Monolith.Domain.RepositoryInterfaces;

namespace src.Monolith.ApplicationService;

public interface ICustomerService
{
    IEnumerable<Customer> GetCustomers();
    Customer? GetCustomerById(Guid id);
    CustomerMyPage GetCustomerMyPage(Guid customerId);
}

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerMyPage _customerMyPage;
    
    public CustomerService(ICustomerRepository customerRepository, ICustomerMyPage customerMyPage)
    {
        _customerRepository = customerRepository;
        _customerMyPage = customerMyPage;
    }
    
    public IEnumerable<Customer> GetCustomers()
    {
        return _customerRepository.GetCustomers();
    }

    public Customer? GetCustomerById(Guid id)
    {
        return _customerRepository.GetCustomerById(id);
    }
    
    public CustomerMyPage GetCustomerMyPage(Guid customerId)
    {
        return _customerMyPage.GetCustomerMyPage(customerId);
    }
}
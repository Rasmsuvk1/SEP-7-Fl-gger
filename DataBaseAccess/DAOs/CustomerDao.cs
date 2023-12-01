using Application.Idao;
using Domain.DTOs.CustomerDTOS;
using Domain.Models;

namespace DataBaseAccess.DAOs;

public class CustomerDao : ICustomerDao
{
    private static List<CustomerInfo> customers = new List<CustomerInfo>();
    public Task<CustomerInfo> CreateAsync(CustomerCreationDto customerToCreate)
    {
        int index = customers.Count;
        CustomerInfo created = new CustomerInfo(customerToCreate.Name, customerToCreate.Email, customerToCreate.Tlf,
            customerToCreate.address);
        created.CustomerId = index;
        customers.Add(created);
        return Task.FromResult(created);

    }

    public Task<CustomerInfo> GetCustomerAsync(GetCustomerDto dto)
    {
       
        CustomerInfo? returnCustomer = customers.Find(customer => customer.Tlf == dto.Tlf || customer.Email == dto.Email || customer.Name == dto.Name);
        if (returnCustomer == null)
        {
            throw new Exception("No customer was found");
        }
        return Task.FromResult(returnCustomer);

    }
}
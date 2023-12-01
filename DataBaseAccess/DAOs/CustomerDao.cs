using Application.Idao;
using DataBaseAccess.DBContext;
using Domain.DTOs.CustomerDTOS;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DAOs;

public class CustomerDao : ICustomerDao
{
    private readonly DatabaseContext _context;

    public CustomerDao(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<CustomerInfo> CreateAsync(CustomerCreationDto customerToCreate)
    {
        
        CustomerInfo created = new CustomerInfo(customerToCreate.Name, customerToCreate.Email, customerToCreate.Tlf,
            customerToCreate.address);
        await _context.customerinfo.AddAsync(created);
        await  _context.SaveChangesAsync();
        return created;

    }

    //Optimize this
    public async Task<CustomerInfo> GetCustomerAsync(GetCustomerDto dto)
    {
       
        List<CustomerInfo> customers = await _context.customerinfo.ToListAsync();
        CustomerInfo? customer = customers.Find(customer =>
            customer.Tlf == dto.Tlf || customer.Email == dto.Email || customer.Name == dto.Name);
        if (customer == null)
        {
            throw new Exception("No customer was found");
        }
        return customer;

    }
}
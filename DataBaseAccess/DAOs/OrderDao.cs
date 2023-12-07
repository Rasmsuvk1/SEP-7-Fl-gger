using Application.Idao;
using DataBaseAccess.DBContext;
using Domain.DTOs.OrderDTOS;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DAOs;

public class OrderDao : IOrderDao
{

    private readonly DatabaseContext _context;

    public OrderDao(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateAsync(OrderCreationDto orderToCreate)
    {
        try
        {
            //Creating the order:
            Order creationOrder = new Order(orderToCreate.PurchaseDate, orderToCreate.DeliveryMethod,
                orderToCreate.Customer.CustomerId);
            await _context.sale.AddAsync(creationOrder);
            await _context.SaveChangesAsync();

            List<ProductSalesRelation> newPSR = new List<ProductSalesRelation>();
            //Creating the products in the order
            foreach (var productId in orderToCreate.ProductIds)
            {
                newPSR.Add(new ProductSalesRelation(creationOrder.OrderId, productId));
            }

            await _context.productSalesRelations.AddRangeAsync(newPSR);
            await _context.SaveChangesAsync();
            return creationOrder;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception("Error creating new Order!");
        }
    }

    
    //Method for retrieving a list of orders based on different critera
    public async Task<List<ReturningOrderDto>> GetAsync(GetOrderDto dto)
    {
        List<ReturningOrderDto> returnDto = new List<ReturningOrderDto>();

        //A list for storing info on the customer we want to get (Only used when info about the customer is provided by DTO)
        List<CustomerInfo> customers = new List<CustomerInfo>();

        //Querys that specifies what should be retrieved from the different tables.
        var orderQuery = _context.sale.AsQueryable();
        var productSalesRelationQuery = _context.productSalesRelations.AsQueryable();
        var productQuery = _context.product.AsQueryable();
        var customerQuery = _context.customerinfo.AsQueryable();

        if (!string.IsNullOrEmpty(dto.Name))
        {
            customers = await WithName(dto, customerQuery);
        }

        if (dto.CustomerId > 0)
        {
            customers = await WithCustomerId(dto, customerQuery);
        }

        if (dto.PurchaseDate.HasValue)
        {
            returnDto = await ByDate(dto, customerQuery);
        }

        if (dto.OrderId > 0)
        {
            returnDto.Add(await WithOrderId(dto, customerQuery));
        }

        //If we want information on orders based on information on customer:
        if (!string.IsNullOrEmpty(dto.Name) || dto.CustomerId > 0)
        {

            // Getting all the orders that a certain name has created:
            foreach (var customer in customers)
            {
                Order? relevantOrder =
                    await orderQuery.FirstOrDefaultAsync(order => order.CustomerId == customer.CustomerId);
                if (relevantOrder != null)
                {
                    // Get a list of the product ids:
                    List<int> productIds = productSalesRelationQuery
                        .Where(psr => psr.OrderId == relevantOrder.OrderId)
                        .Select(psr => psr.ProductId)
                        .ToList();

                    //getting a list of products based on the ids:
                    List<Product> products = productQuery
                        .Where(p => productIds.Contains(p.ProductId))
                        .ToList();

                    // Create ReturningOrderDto based on your requirements
                    ReturningOrderDto orderDto = new ReturningOrderDto(relevantOrder.OrderId, customer.Name,
                        customer.Email,
                        customer.Tlf, customer.address, relevantOrder.DeliveryMethod, relevantOrder.PurchaseDate, products);

                    returnDto.Add(orderDto);
                }

            }
        }
        return returnDto;
    }

//Sets the customer list
    private async Task<List<CustomerInfo>> WithName(GetOrderDto dto, IQueryable<CustomerInfo> customerQuery)
    {
        // Get All Customer entries with a specified name:
        return await customerQuery.Where(customer => customer.Name.Equals(dto.Name))
            .ToListAsync();
    }
//Sets the customer list
    private async Task<List<CustomerInfo>> WithCustomerId(GetOrderDto dto, IQueryable<CustomerInfo> customerQuery)
    {
        // Get All Customer entries with a specified name:
        return await customerQuery.Where(customer => customer.CustomerId == dto.CustomerId)
            .ToListAsync();
    }
    //Retrives one entry from the db based on order id
    private async Task<ReturningOrderDto> WithOrderId(GetOrderDto dto, IQueryable<CustomerInfo> customerQuery)
    {
        ReturningOrderDto returnDto = new ReturningOrderDto();

        var orderQuery = _context.sale.AsQueryable();
        var productSalesRelationQuery = _context.productSalesRelations.AsQueryable();
        var productQuery = _context.product.AsQueryable();


        Order? relevantOrder = await orderQuery.FirstOrDefaultAsync(order => order.OrderId == dto.OrderId);
        if (relevantOrder != null)
        {
            CustomerInfo? relevantCustomer =
                await customerQuery.FirstOrDefaultAsync(customer => customer.CustomerId == relevantOrder.CustomerId);
            // Get a list of the product ids:
            List<int> productIds = await productSalesRelationQuery
                .Where(psr => psr.OrderId == relevantOrder.OrderId)
                .Select(psr => psr.ProductId)
                .ToListAsync();

            //getting a list of products based on the ids:
            List<Product> products = await productQuery
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync();

            // Create ReturningOrderDto based on your requirements
            ReturningOrderDto orderDto = new ReturningOrderDto(relevantOrder.OrderId, relevantCustomer.Name,
                relevantCustomer.Email,
                relevantCustomer.Tlf, relevantCustomer.address, relevantOrder.DeliveryMethod, relevantOrder.PurchaseDate, products);

            returnDto = orderDto;
        }

        return returnDto;
    }

//Retrives a list of orders that was done on a specific date
private async Task<List<ReturningOrderDto>> ByDate(GetOrderDto dto, IQueryable<CustomerInfo> customerQuery)
    {
        List<ReturningOrderDto> returnDto = new List<ReturningOrderDto>();

        var orderQuery = _context.sale.AsQueryable();
        var productSalesRelationQuery = _context.productSalesRelations.AsQueryable();
        var productQuery = _context.product.AsQueryable();


        List<Order>? relevantOrder = await orderQuery.Where(order => order.PurchaseDate == dto.PurchaseDate).ToListAsync();
        if (relevantOrder.Count > 0)
        {
            foreach (var order in relevantOrder)
            {
                CustomerInfo? relevantCustomer =
                    await customerQuery.FirstOrDefaultAsync(customer => customer.CustomerId == order.CustomerId);
                // Get a list of the product ids:
                List<int> productIds = productSalesRelationQuery
                    .Where(psr => psr.OrderId == order.OrderId)
                    .Select(psr => psr.ProductId)
                    .ToList();

                //getting a list of products based on the ids:
                List<Product> products = productQuery
                    .Where(p => productIds.Contains(p.ProductId))
                    .ToList();

                // Create ReturningOrderDto based on your requirements
                ReturningOrderDto orderDto = new ReturningOrderDto(order.OrderId, relevantCustomer.Name,
                    relevantCustomer.Email,
                    relevantCustomer.Tlf, relevantCustomer.address, order.DeliveryMethod, order.PurchaseDate, products);

                returnDto.Add(orderDto);
            }
        }

        return returnDto;
    }
    
    
}
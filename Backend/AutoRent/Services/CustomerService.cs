using AutoRent.Data;
using AutoRent.DTOs.Customer;
using AutoRent.Interfaces;
using AutoRent.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRent.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AutoRentDbContext _context;

        public CustomerService(AutoRentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            return await _context.Customers.Where(c => !c.IsDeleted).Select(c => new CustomerDto { 
                Id = c.id,
                FullName = $"{c.FirstName} {c.LastName}",
                Email = c.Email,
                DocumentId = c.DocumentId,
                Phone = c.Phone,
                Address = c.Address
            
            }).ToArrayAsync();
        }

        public async Task<CreateCustomerDto?> GetByIdAsync(string id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.id == id && !c.IsDeleted);
            if (customer == null) return null;

            return new CreateCustomerDto
            {
                firstName = $"{customer.FirstName} {customer.LastName}",
                lastName = customer.LastName,
                email = customer.Email,
                documentId = customer.DocumentId,
                phone = customer.Phone,
                address = customer.Address
            };
        }


        public async Task<CustomerDto> CreateAsync (CreateCustomerDto dto)
        {
            var customer = new Customer {
            
                id = Guid.NewGuid().ToString(),
                FirstName = dto.firstName,
                LastName = dto.lastName,
                Email = dto.email,
                Address = dto.address,
                Phone = dto.phone,
                DocumentId = dto.documentId,
                
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return new CustomerDto
            {
                Id = customer.id,
                FullName = $"{customer.FirstName} {customer.LastName}",
                Email = customer.Email,
                DocumentId = customer.DocumentId,
                Phone = customer.Phone,
                Address = customer.Address
            };

        }

        public async Task<bool> DeleteAsync(string id) {
        
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null || customer.IsDeleted) return false;

            customer.IsDeleted = true; 
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditAsync(string id, CreateCustomerDto dto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.id == id);
            if (customer == null) return false;

            customer.FirstName = dto.firstName;
            customer.LastName = dto.lastName;
            customer.Email = dto.email;
            customer.Address = dto.address;
            customer.Phone = dto.phone;
            customer.DocumentId = dto.documentId;

            await _context.SaveChangesAsync();

            return true;
   
        }
    }
}

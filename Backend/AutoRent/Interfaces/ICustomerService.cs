using AutoRent.DTOs.Customer;

namespace AutoRent.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CreateCustomerDto?> GetByIdAsync(string id);
        Task<CustomerDto> CreateAsync (CreateCustomerDto customerDto);
        Task<bool> EditAsync (string id,CreateCustomerDto customerDto);
        Task<bool> DeleteAsync (string id);
    }
}

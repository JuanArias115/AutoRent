using AutoRent.DTOs.Car;
using AutoRent.DTOs.Customer;

namespace AutoRent.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllAsync();
        Task<CreateCarDto?> GetByIdAsync(string id);
        Task<CarDto?> CreateAsync(CreateCarDto dto);
        Task<bool> EditAsync(string id, CreateCarDto dto);

        Task<bool> DeleteAsync(string id);
    }
}

using AutoRent.DTOs.Rental;

namespace AutoRent.Interfaces
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDto>> GetAllAsync();
        Task<RentalDto?> GetByIdAsync(string id);
        Task<RentalDto> CreateAsync (CreateRentalDto dto);
        Task<bool> ReturnRentalAsync(String rentalId, ReturnRentalDto dto);
        Task<bool> DeleteAsync(string rentalId);
        Task<RentalCheckOutDto?> CheckOut(string rentalId, requestRentalCheckOut dto);

    }
}

using AutoRent.Data;
using AutoRent.DTOs.Rental;
using AutoRent.Interfaces;
using AutoRent.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace AutoRent.Services
{
    public class RentalService : IRentalService
    {

        private readonly AutoRentDbContext _context;

        public RentalService(AutoRentDbContext context)
        {
            _context = context;
        }

        public async Task<RentalDto> CreateAsync(CreateRentalDto dto)
        {
            var Car = await _context.Cars.FindAsync(dto.carId);
            var Customer = await _context.Customers.FindAsync(dto.customerId);

            if(Car == null || !Car.IsAvailable)
            {
                throw new InvalidOperationException("Car not found");
            }

            if (Customer == null || Customer.IsDeleted)
            {
                throw new InvalidOperationException("Invalid Customer");
            }

            int duration = (dto.expectedDate - dto.startDate).Days;

            var rental = new Rental
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = dto.customerId,
                CarId = dto.carId,
                StartDate = dto.startDate,
                ExpectedDate = dto.expectedDate,
                StartKm = Car.CurrentKm,
                IsUnlimitedKm = dto.isUnlimitedKm,
                EndKm = (duration * Car.kmDay) + Car.CurrentKm,
            };

            Car.IsAvailable = false;

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            var res = await GetByIdAsync(rental.Id);

            return res ?? throw new Exception("Failed to create rental");

        }

        public async Task<bool> ReturnRentalAsync(string rentalId, ReturnRentalDto dto)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.Id == rentalId);

            if(rental == null || rental.ActualReturn != null)
            {
                return false;
            }

            if(dto.returnKm < rental.StartKm)
            {
                throw new InvalidOperationException("Return kilometrs must be greater than initial kilometers");
            }

            rental.ActualReturn = dto.actualReturn; 
            rental.EndKm = dto.returnKm;
            rental.totalPaid = dto.totalPaid;

            rental.Car.CurrentKm = dto.returnKm;
            rental.Car.IsAvailable = true;
            rental.Status = "Returned";

            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<RentalDto>> GetAllAsync()
        {
            return await _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Car)
                .OrderByDescending(r => r.StartDate)
                .Select(r => new RentalDto { 
                    id = r.Id,
                    customerName = $"{r.Customer.FirstName} {r.Customer.LastName}",
                    carModel = $"{r.Car.Brand} {r.Car.Model}",
                    carId = r.Car.id,
                    startDate = r.StartDate,
                    expectedDate = r.ExpectedDate,
                    actualReturn = r.ActualReturn,
                    startKm = r.StartKm,
                    endKm = r.EndKm,
                    status = r.Status,
                    isUnlimitedKm = r.IsUnlimitedKm ? "Yes" : "No",
                    totalPaid = r.totalPaid ?? 0
                }).ToListAsync();

        }

        public async Task<RentalDto?> GetByIdAsync(string id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == id);

            if(rental == null) return null;

            return new RentalDto
            {
                id = rental.Id,
                customerName = $"{rental.Customer.FirstName} {rental.Customer.LastName}",
                carModel = $"{rental.Car.Brand} {rental.Car.Model}",
                carId = rental.Car.id,
                startDate = rental.StartDate,
                expectedDate = rental.ExpectedDate,
                actualReturn = rental.ActualReturn,
                startKm = rental.StartKm,
                endKm = rental.EndKm,
                status = rental.ActualReturn == null ? "Active" : "Returned",
                isUnlimitedKm = rental.IsUnlimitedKm ? "Yes" : "No",
                totalPaid = rental.totalPaid ?? 0
            };
        }

        public async Task<bool> DeleteAsync(string rentalId)
        {
            var rental = await _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == rentalId);

            if(rental == null || rental.ActualReturn != null) return false;

            rental.Car.IsAvailable = true;

            _context.Rentals.Remove(rental);

            await _context.SaveChangesAsync();

            return true;
           
        }


        public async Task<RentalCheckOutDto> CheckOut(string rentalId, requestRentalCheckOut dto)
        {
            var rental = await _context.Rentals
            .Include(r => r.Customer)
            .Include(r => r.Car)
            .FirstOrDefaultAsync(r => r.Id == rentalId);

            if (rental == null || rental.ActualReturn != null) return null;

            int duration = (rental.StartDate - dto.actualDate).Days;
            if (duration == 0) duration = 1;
            int lateDays = (dto.actualDate - rental.ExpectedDate).Days;
            int maxKm = (rental.Car.CurrentKm + (rental.Car.kmDay * duration));


            int excessKm = 0;

            if (!rental.IsUnlimitedKm) excessKm = dto.actualKm - maxKm;


            if (excessKm < 0) excessKm = 0;
            if (lateDays < 0) lateDays = 0;

            var checkOut = new RentalCheckOutDto
            {
                car = $"{rental.Car.Brand} {rental.Car.Model}",
                rentalDuration = duration,
                rentCost = rental.Car.dailyPrice * duration,
                lateReturnFee = lateDays * rental.Car.dailyPenaltyFee,
                excessKmFee = excessKm * rental.Car.kmPenaltyFee
            };


            return checkOut;
        }
    }
}

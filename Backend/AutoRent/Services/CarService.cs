using AutoRent.Data;
using AutoRent.DTOs.Car;
using AutoRent.DTOs.Customer;
using AutoRent.Interfaces;
using AutoRent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace AutoRent.Services
{
    public class CarService : ICarService
    {

        private readonly AutoRentDbContext _context;

        public CarService(AutoRentDbContext context)
        {
            _context = context; 
        }


        public async Task<CarDto?> CreateAsync(CreateCarDto dto)
        {
            var car = new Car
            {
                id = Guid.NewGuid().ToString(),
                Brand = dto.brand,
                Model = dto.model,  
                Year = dto.year,
                CurrentKm = dto.currentKm,
                PlateNumber = dto.plateNumber,
                ImageUrl = dto.imageUrl ?? "https://cdn-icons-png.flaticon.com/128/1048/1048315.png",
                Doors = dto.doors,
                Capacity = dto.capacity,
                EmissionClass = dto.emissionClass,
                FuelType = dto.fuelType,
                transmission = dto.transmission,
                kmDay = dto.kmDay,
                kmPenaltyFee = dto.kmPenaltyFee,
                dailyPrice = dto.dailyPrice,
                dailyPenaltyFee = dto.dailyPenaltyFee,
                unlimitedKmFee = dto.unlimitedKmFee
            };

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return new CarDto
            {
                brand = dto.brand,
                model = dto.model,
                plateNumber = dto.plateNumber,
                currentKm = dto.currentKm
            };
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var car = await _context.Cars.FindAsync(id);
            if(car == null || car.IsDeleted) return false;
            
            car.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CarDto>> GetAllAsync()
        {
            return await _context.Cars.Where(c => !c.IsDeleted).Select(s =>
                new CarDto
                {
                    id = s.id,
                    brand = s.Brand,
                    model = s.Model,
                    Year = s.Year,
                    plateNumber = s.PlateNumber,
                    currentKm = s.CurrentKm,
                    isAvailable = s.IsAvailable,
                    imageUrl = s.ImageUrl
                    
                }
            ).ToListAsync();
        }

        public async Task<CreateCarDto?> GetByIdAsync(string id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.id == id);

            if (car == null) return null;

            return new CreateCarDto
            {
                brand = car.Brand,
                model = car.Model,
                year = car.Year,
                plateNumber = car.PlateNumber,
                currentKm = car.CurrentKm,
                imageUrl = car.ImageUrl,
                doors = car.Doors,
                capacity = car.Capacity,
                emissionClass = car.EmissionClass,
                fuelType = car.FuelType,
                transmission = car.transmission,
                kmDay = car.kmDay,
                kmPenaltyFee = car.kmPenaltyFee,
                dailyPrice = car.dailyPrice,
                dailyPenaltyFee = car.dailyPenaltyFee,
                unlimitedKmFee = car.unlimitedKmFee
            };

        }


        public async Task<bool> EditAsync(string id, CreateCarDto dto)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.id == id);
            if (car == null) return false;

            car.Brand = dto.brand;
            car.Model = dto.model;
            car.Year = dto.year;
            car.PlateNumber = dto.plateNumber;
            car.CurrentKm = dto.currentKm;
            car.ImageUrl = dto.imageUrl;
            car.Doors = dto.doors;
            car.Capacity = dto.capacity;
            car.EmissionClass = dto.emissionClass;
            car.FuelType = dto.fuelType;
            car.transmission = dto.transmission;
            if (dto.imageUrl != null) car.ImageUrl = dto.imageUrl;
            car.kmDay = dto.kmDay;
            car.kmPenaltyFee = dto.kmPenaltyFee;
            car.dailyPrice = dto.dailyPrice;
            car.dailyPenaltyFee = dto.dailyPenaltyFee;
            car.unlimitedKmFee = dto.unlimitedKmFee;

            await _context.SaveChangesAsync();

            return true;

        }
    }
}

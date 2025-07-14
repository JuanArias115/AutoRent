using System.ComponentModel.DataAnnotations;

namespace AutoRent.Models
{
    public class Car
    {
        public string id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        public int Year { get; set; }
        public int CurrentKm { get; set; }
        public string ImageUrl { get; set; } 
        public bool IsAvailable { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public int? Doors {  get; set; } 
        public int? Capacity { get; set; }
        public string? EmissionClass { get; set; }
        public string? FuelType { get; set; }   
        public string? transmission { get; set; }


        public int kmDay { get; set; }
        public double kmPenaltyFee { get; set; }
        public double dailyPrice { get; set; }
        public double dailyPenaltyFee { get; set; }
        public double unlimitedKmFee { get; set; }


        public ICollection<Rental> Rentals { get; set; }


    }
}

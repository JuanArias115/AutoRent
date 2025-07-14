namespace AutoRent.DTOs.Car
{
    public class CreateCarDto
    {
        public string brand { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string plateNumber { get; set; }
        public string? imageUrl { get; set; }
        public int currentKm { get; set; }

        public int? doors { get; set; }
        public int? capacity { get; set; }
        public string? emissionClass { get; set; }
        public string? fuelType { get; set; }
        public string? transmission { get; set; }

        public int kmDay { get; set; }
        public double kmPenaltyFee { get; set; }
        public double dailyPrice { get; set; }
        public double dailyPenaltyFee { get; set; }
        public double unlimitedKmFee { get; set; }


        public DateTime created_at { get; set; } = DateTime.Now;
    }
}

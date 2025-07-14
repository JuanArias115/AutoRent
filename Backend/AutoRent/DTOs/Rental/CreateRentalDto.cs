namespace AutoRent.DTOs.Rental
{
    public class CreateRentalDto
    {
        public string customerId { get; set; } = null;
        public string carId { get; set; } = null;
        public DateTime startDate { get; set; }

        public DateTime expectedDate { get; set; }
        public bool isUnlimitedKm { get; set; } 

        


    }
}

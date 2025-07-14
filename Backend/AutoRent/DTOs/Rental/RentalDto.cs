namespace AutoRent.DTOs.Rental
{
    public class RentalDto
    {
        public string id { get; set; }
        public string customerName { get; set; } = null;
        public string carModel { get; set; } = null;
        public string carId { get; set; } = null;
        public DateTime startDate { get; set; }
        public DateTime expectedDate { get; set; }
        public DateTime? actualReturn { get; set; }
        public int startKm { get; set; }
        public int? endKm { get; set; }
        public string status { get; set; }
        public double totalPaid { get; set; }
        public string isUnlimitedKm { get; set; }
    } 
}

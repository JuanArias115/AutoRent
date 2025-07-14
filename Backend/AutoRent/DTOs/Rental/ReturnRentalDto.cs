namespace AutoRent.DTOs.Rental
{
    public class ReturnRentalDto
    {
        public int returnKm { get; set; }
        public DateTime actualReturn { get; set; }
        public double totalPaid { get; set; }
    }
}

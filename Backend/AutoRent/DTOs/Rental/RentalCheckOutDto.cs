namespace AutoRent.DTOs.Rental
{
    public class RentalCheckOutDto
    {
        public string car { get; set; }
        public int rentalDuration { get; set; }
        public double rentCost { get; set; }
        public double lateReturnFee { get; set; }
        public double excessKmFee { get; set; }

    }
}

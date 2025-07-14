namespace AutoRent.DTOs.Car
{
    public class CarDto
    {
        public string id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int Year { get; set; }
        public string plateNumber { get; set; }
        public int currentKm { get; set; }
        public bool isAvailable { get; set; }
        public string imageUrl { get; set; }




    }
}

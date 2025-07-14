using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRent.Models
{
    public class Rental
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string CarId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("CarId")]
        public Car Car { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? ActualReturn {  get; set; }
        public int StartKm { get; set; }
        public int EndKm { get; set; }
        public int? ActualKm { get; set; }

        public string Status { get; set; } = "active";
        public bool IsDeleted { get; set; } = false;

        public double? totalPaid { get; set; }

        public bool IsUnlimitedKm { get; set; } 
    }
}

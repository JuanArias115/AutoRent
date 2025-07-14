using System.ComponentModel.DataAnnotations;

namespace AutoRent.Models
{
    public class Customer
    {
        public string id { get; set; } = Guid.NewGuid().ToString(); 

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string DocumentId { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone {  get; set; }

        public string Address { get; set; }
        public bool IsDeleted { get; set; } // soft delete 
        public ICollection<Rental> Rentals { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AutoRent.DTOs.Customer
{
    public class CreateCustomerDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string documentId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace AutoRent.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Username { get; set; }
        public string passwordhash { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Onboarding_API.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Onboarding_API.ViewModels
{
    public class AddUpdateProductVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}

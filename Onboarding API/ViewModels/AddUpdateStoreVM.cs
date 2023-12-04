using System.ComponentModel.DataAnnotations;

namespace Onboarding_API.ViewModels
{
    public class AddUpdateStoreVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

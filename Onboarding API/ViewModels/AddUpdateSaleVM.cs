using System.ComponentModel.DataAnnotations;

namespace Onboarding_API.ViewModels
{
    public class AddUpdateSaleVM
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public DateTime DateSold { get; set; }
    }
}

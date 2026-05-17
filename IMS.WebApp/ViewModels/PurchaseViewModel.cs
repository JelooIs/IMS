using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class PurchaseViewModel
    {
        [Required]
        public string PONumber { get; set; } = string.Empty;


        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Please select a valid inventory item.")]
        public int InventoryId { get; set; }
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Please enter a valid quantity.")] public int ItemId { get; set; }
        public int QuantityToPurchase { get; set; }
        public double InventoryPrice { get; set; }
    }
}

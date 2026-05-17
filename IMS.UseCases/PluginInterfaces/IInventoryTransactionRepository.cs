using IMS.CoreBusiness;

namespace IMS.Plugins.InMemory
{
    public interface IInventoryTransactionRepository
    {
        List<InventoryTransaction> _inventoryTransactions { get; set; }

        void PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price);
        Task UpdateInventoryAsync(Inventory inventory);
    }
}
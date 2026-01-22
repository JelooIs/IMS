using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product { ProductId = 1, ProductName = "Garba Bowl", Quantity = 12, Price = 10 },
                new Product { ProductId = 2, ProductName = "Allocco Box", Quantity = 70, Price = 5 },



            };
        }

        public Task AddProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            { return Task.CompletedTask; }

            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;

            _products.Add(product);

            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(Product product)
        {
            return await Task.FromResult(
                _products.Any(x => x.ProductId != product.ProductId &&
                x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))
            );
        }

        public Task DeleteProductByIdAsync(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_products);

            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            var prod = _products.FirstOrDefault(x => x.ProductId == productId);
            var newPROD = new Product();
            if (prod != null)
            {
                newPROD.ProductId = prod.ProductId;
                newPROD.ProductName = prod.ProductName;
                newPROD.Quantity = prod.Quantity;
                newPROD.Price = prod.Price;
                newPROD.ProductInventories = new List<ProductInventory>();
                if (prod.ProductInventories != null && prod.ProductInventories.Count > 0)
                {
                    foreach(var prodInv in prod.ProductInventories)
                    {
                        var NewProdInv = new ProductInventory
                        {
                            InventoryId = prodInv.InventoryId,
                            ProductId = prodInv.ProductId,
                            Product = prod,
                            Inventory = new Inventory(),
                            InventoryQuantity = prodInv.InventoryQuantity
                        };
                        if (prodInv.Inventory != null)
                        {
                            NewProdInv.Inventory.InventoryId = prodInv.Inventory.InventoryId;
                            NewProdInv.Inventory.InventoryName = prodInv.Inventory.InventoryName;
                            NewProdInv.Inventory.Quantity = prodInv.Inventory.Quantity;
                            NewProdInv.Inventory.Price = prodInv.Inventory.Price;
                        }

                        newPROD.ProductInventories.Add(NewProdInv);
                    }
                }
            }
            return await Task.FromResult(newPROD);
        }

        public Task UpdateProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductId != product.ProductId &&
                x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var prod = _products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.Quantity = product.Quantity;
                prod.Price = product.Price;
                prod.ProductInventories = prod.ProductInventories;
            }

            return Task.CompletedTask;
        }
    }
}

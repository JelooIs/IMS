using IMS.CoreBusiness;
using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository productRepository;

        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task ExecuteAsync(Product product)
        {
            await this.productRepository.UpdateProductAsync(product);
        }

    }
}

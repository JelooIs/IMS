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
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(int productId)
        {
            await this.productRepository.DeleteProductByIdAsync(productId);
        }
    }
}

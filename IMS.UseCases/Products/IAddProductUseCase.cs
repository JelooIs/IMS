using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}
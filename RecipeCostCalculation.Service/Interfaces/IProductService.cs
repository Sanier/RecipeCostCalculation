using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Models;
using RecipeCostCalculation.Domain.Response;

namespace RecipeCostCalculation.Service.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<IEnumerable<AvailableProductsModel>>> GetProductsInFridge();
        Task<IBaseResponse<ProductEntity>> Create(CreateProductModel createFridgeModel);
        Task<IBaseResponse<IEnumerable<AvailableProductsModel>>> DeleteProductsInFridge(long id);
        Task<IBaseResponse<IEnumerable<AvailableProductsModel>>> ChangeProductsInFridge(AvailableProductsModel model);
    }
}

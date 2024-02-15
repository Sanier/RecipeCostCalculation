using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Models;
using RecipeCostCalculation.Domain.Response;

namespace RecipeCostCalculation.Service.Interfaces
{
    public interface IFridgeService
    {
        Task<IBaseResponse<IEnumerable<AvailableProductsFridgeModel>>> GetProductsInFridge();
        Task<IBaseResponse<FridgeEntity>> Create(CreateFridgeModel createFridgeModel);
        Task<IBaseResponse<IEnumerable<AvailableProductsFridgeModel>>> DeleteProductsInFridge(long id);
        Task<IBaseResponse<IEnumerable<AvailableProductsFridgeModel>>> ChangeProductsInFridge(AvailableProductsFridgeModel model);
    }
}

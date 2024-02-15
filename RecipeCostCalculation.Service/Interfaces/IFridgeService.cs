using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Models;
using RecipeCostCalculation.Domain.Response;

namespace RecipeCostCalculation.Service.Interfaces
{
    public interface IFridgeService
    {
        Task<IBaseResponse<IEnumerable<AvailableProductsFridge>>> GetProductsInFridge();
        Task<IBaseResponse<FridgeEntity>> Create(CreateFridgeModel createFridgeModel);
    }
}

using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Models.ProductModels;
using RecipeCostCalculation.Domain.Response;

namespace RecipeCostCalculation.Service.Interfaces
{
    /// <summary>
    /// The IProductService interface defines the operations for managing products.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Asynchronously gets all products in the fridge.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a response with a list of available products.</returns>
        Task<IBaseResponse<IEnumerable<AvailableProductsModel>>> GetProductsInFridge();

        /// <summary>
        /// Asynchronously creates a new product.
        /// </summary>
        /// <param name="createFridgeModel">The model for creating a new product.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a response with the created product entity.</returns>
        Task<IBaseResponse<ProductEntity>> Create(CreateProductModel createFridgeModel);

        /// <summary>
        /// Asynchronously deletes a product in the fridge.
        /// </summary>
        /// <param name="id">The ID of the product to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a response with a list of available products after deletion.</returns>
        Task<IBaseResponse<IEnumerable<AvailableProductsModel>>> DeleteProductsInFridge(long id);

        /// <summary>
        /// Asynchronously changes a product in the fridge.
        /// </summary>
        /// <param name="model">The model of the product to be changed.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a response with a list of available products after the change.</returns>
        Task<IBaseResponse<IEnumerable<AvailableProductsModel>>> ChangeProductsInFridge(AvailableProductsModel model);
    }
}

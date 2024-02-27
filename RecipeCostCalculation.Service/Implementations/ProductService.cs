using Microsoft.Extensions.Logging;
using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Enums;
using RecipeCostCalculation.Domain.Models.ProductModels;
using RecipeCostCalculation.Domain.Response;
using RecipeCostCalculation.Service.Interfaces;

namespace RecipeCostCalculation.Service.Implementations
{
    /// <summary>
    /// The ProductService class implements the IProductService interface.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IBaseRepositories<ProductEntity> _fridgeRepository;
        private ILogger<ProductService> _logger;

        /// <summary>
        /// Constructor for the ProductService class.
        /// </summary>
        /// <param name="fridgeRepository">A repository of ProductEntity objects.</param>
        /// <param name="logger">A logger for the ProductService class.</param>
        public ProductService(IBaseRepositories<ProductEntity> fridgeRepository, ILogger<ProductService> logger)
        {
            _fridgeRepository = fridgeRepository;
            _logger = logger;
        }

        /// <summary>
        /// Asynchronously gets all products in the fridge.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a response with a list of available products.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the list of products is null.</exception>
        public async Task<IBaseResponse<IEnumerable<AvailableProductsModel>>> GetProductsInFridge()
        {
            try
            {
                var list = _fridgeRepository.GetAll()
                    .Select(l => new AvailableProductsModel
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Count = l.Count,
                        Price = l.Price,
                        EnergyValue = l.EnergyValue
                    })
                    .ToList();

                if (list is null)
                    throw new ArgumentNullException();

                return OutputProcessing<IEnumerable<AvailableProductsModel>>(list, StatusCode.Success);
            }
            catch(Exception ex)
            {
                return HandleException<IEnumerable<AvailableProductsModel>>(ex, "FridgeService.GetProductsInFridge");
            }
        }

        /// <summary>
        /// Asynchronously creates a new product.
        /// </summary>
        /// <param name="createFridgeModel">The model for creating a new product.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a response with the created product entity.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public async Task<IBaseResponse<ProductEntity>> Create(CreateProductModel createFridgeModel)
        {
            try
            {
                createFridgeModel.Validate();

                //_logger.LogInformation($"Request for product entry - {createFridgeModel.Name}");

                var list = _fridgeRepository.GetAll()
                    .FirstOrDefault(l => l.Name == createFridgeModel.Name);


                list = new ProductEntity()
                {
                    Id = createFridgeModel.Id,
                    Name = createFridgeModel.Name,
                    Count = createFridgeModel.Count,
                    Price = createFridgeModel.Price,
                    EnergyValue = createFridgeModel.EnergyValue,
                    //DateOfManufacture = DateTime.Now,
                    //ExpirationDate = DateTime.Now
                };

                await _fridgeRepository.Create(list);

                //_logger.LogInformation($":");

                await _fridgeRepository.Update(list);
                return OutputProcessing<ProductEntity>("The task has been created", StatusCode.Success);
            }
            catch (Exception ex)
            {
                return HandleException<ProductEntity>(ex, "FridgeService.Create");
            }
        }

        /// <summary>
        /// Asynchronously deletes a product in the fridge.
        /// </summary>
        /// <param name="id">The ID of the product to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a response with a list of available products after deletion.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the product to be deleted is not found.</exception>
        public async Task<IBaseResponse<IEnumerable<AvailableProductsModel>>> DeleteProductsInFridge(long id)
        {
            try
            {
                var list = _fridgeRepository.GetAll()
                    .FirstOrDefault(l => l.Id == id);

                if (list is null)
                    throw new ArgumentNullException();

                await _fridgeRepository.Delete(list);
                await _fridgeRepository.Update(list);

                return OutputProcessing<IEnumerable<AvailableProductsModel>>("The task has been deleted", StatusCode.Success);
            }
            catch (Exception ex)
            {
                return HandleException<IEnumerable<AvailableProductsModel>>(ex, "FridgeService.DeleteProductsInFridge");
            }
        }

        /// <summary>
        /// Asynchronously changes a product in the fridge.
        /// </summary>
        /// <param name="model">The model of the product to be changed.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a response with a list of available products after the change.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the product to be changed is not found.</exception>
        public async Task<IBaseResponse<IEnumerable<AvailableProductsModel>>> ChangeProductsInFridge(AvailableProductsModel model)
        {
            try
            {
                var list = _fridgeRepository.GetAll()
                    .FirstOrDefault(l => l.Id == model.Id);

                list = new ProductEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Count = model.Count,
                    Price = model.Price,
                    EnergyValue = model.EnergyValue,
                    DateOfManufacture = DateTime.Now,
                };

                if (list is null)
                    throw new ArgumentNullException();

                await _fridgeRepository.Update(list);

                return OutputProcessing<IEnumerable<AvailableProductsModel>>("The task has been changed", StatusCode.Success);
            }
            catch (Exception ex)
            {
                return HandleException<IEnumerable<AvailableProductsModel>>(ex, "FridgeService.ChangeProductsInFridge");
            }
        }

        #region Private Method

        /// <summary>
        /// Generates a response with a given description and status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="description">The description of the response.</param>
        /// <param name="statusCode">he status code of the response.</param>
        /// <returns>A response with the given description and status code.</returns>
        private BaseResponse<TResponse> OutputProcessing<TResponse>(string description, StatusCode statusCode)
        {
            return new BaseResponse<TResponse>()
            {
                Description = $"{description}",
                StatusCode = statusCode
            };
        }

        /// <summary>
        /// Generates a response with a given task result and status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="task">The task result to be included in the response.</param>
        /// <param name="statusCode">The status code of the response.</param>
        /// <returns>A response with the given task result and status code.</returns>
        private BaseResponse<TResponse> OutputProcessing<TResponse>(TResponse task, StatusCode statusCode)
        {
            return new BaseResponse<TResponse>()
            {
                Data = task,
                StatusCode = statusCode
            };
        }

        /// <summary>
        /// Handles exceptions and generates a response with the exception message and an InternalServerError status code.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="ex">The exception to be handled.</param>
        /// <param name="nameMethod">The name of the method where the exception occurred.</param>
        /// <returns>A response with the exception message and an InternalServerError status code.</returns>
        private BaseResponse<TResponse> HandleException<TResponse>(Exception ex, string nameMethod)
        {
            //_logger.LogError(ex, $"[{nameMethod}]: {ex.Message}");
            return OutputProcessing<TResponse>(ex.Message, StatusCode.InternalServerError);
        }

        #endregion Private Method
    }
}

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Enums;
using RecipeCostCalculation.Domain.Models;
using RecipeCostCalculation.Domain.Response;
using RecipeCostCalculation.Service.Interfaces;

namespace RecipeCostCalculation.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepositories<ProductEntity> _fridgeRepository;
        private ILogger<ProductService> _logger;

        public ProductService(IBaseRepositories<ProductEntity> fridgeRepository, ILogger<ProductService> logger)
        {
            _fridgeRepository = fridgeRepository;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// 
        /// </summary>
        /// <param name="createFridgeModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
                    DateOfManufacture = DateTime.Now,
                    //ExpirationDate = createFridgeModel.ExpirationDate as DateTime
                };

                await _fridgeRepository.Create(list);

                //_logger.LogInformation($":");

                //может не работать сейчас
                await _fridgeRepository.Update(list);
                return OutputProcessing<ProductEntity>("The task has been created", StatusCode.Success);
            }
            catch (Exception ex)
            {
                return HandleException<ProductEntity>(ex, "FridgeService.Create");
            }
        }

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
        /// 
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="description"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        private BaseResponse<TResponse> OutputProcessing<TResponse>(string description, StatusCode statusCode)
        {
            return new BaseResponse<TResponse>()
            {
                Description = $"{description}",
                StatusCode = statusCode
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="task"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        private BaseResponse<TResponse> OutputProcessing<TResponse>(TResponse task, StatusCode statusCode)
        {
            return new BaseResponse<TResponse>()
            {
                Data = task,
                StatusCode = statusCode
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="ex"></param>
        /// <param name="nameMethod"></param>
        /// <returns></returns>
        private BaseResponse<TResponse> HandleException<TResponse>(Exception ex, string nameMethod)
        {
            //_logger.LogError(ex, $"[{nameMethod}]: {ex.Message}");
            return OutputProcessing<TResponse>(ex.Message, StatusCode.InternalServerError);
        }

        #endregion Private Method
    }
}

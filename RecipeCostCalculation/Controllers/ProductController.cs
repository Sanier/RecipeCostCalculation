using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecipeCostCalculation.Domain.Models.ProductModels;
using RecipeCostCalculation.Models;
using RecipeCostCalculation.Service.Interfaces;

namespace RecipeCostCalculation.Controllers
{
    /// <summary>
    /// The ProductController class handles HTTP requests related to products.
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Constructor for the ProductController class.
        /// </summary>
        /// <param name="productService">A service for managing products.</param>
        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        /// <summary>
        /// Returns the Product view.
        /// </summary>
        public IActionResult Product()
        {
            return View();
        }

        /// <summary>
        /// Handles a POST request to create a new product.
        /// </summary>
        /// <param name="createProductModel">The model for creating a new product.</param>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel createProductModel)
        {
            var response = await _productService.Create(createProductModel);

            if (response.StatusCode == Domain.Enums.StatusCode.Success)
                return Ok(new {description = response.Description });

            return BadRequest(new { description = response.Description });
        }

        /// <summary>
        /// Handles a GET request to retrieve all products in the fridge.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetProductsInFridge()
        {
            var response = await _productService.GetProductsInFridge();

            return Json(new {data = response.Data});
        }

        /// <summary>
        /// Handles a DELETE request to delete a product in the fridge.
        /// </summary>
        /// <param name="id">The ID of the product to be deleted.</param>
        [HttpDelete]
        public async Task<IActionResult> DeleteProductsInFridge(long id)
        {
            var response = await _productService.DeleteProductsInFridge(id);

            if (response.StatusCode == Domain.Enums.StatusCode.Success)
                return Ok(new { description = response.Description });

            return BadRequest(new { description = response.Description });
        }

        /// <summary>
        /// Handles a POST request to change a product in the fridge.
        /// </summary>
        /// <param name="model">The model of the product to be changed.</param>
        [HttpPost]
        public async Task<IActionResult> ChangeProductsInFridge(AvailableProductsModel model)
        {
            var response = await _productService.ChangeProductsInFridge(model);

            if (response.StatusCode == Domain.Enums.StatusCode.Success)
                return Ok(new { description = response.Description });

            return BadRequest(new { description = response.Description });
        }

        /// <summary>
        /// Returns the Error view.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

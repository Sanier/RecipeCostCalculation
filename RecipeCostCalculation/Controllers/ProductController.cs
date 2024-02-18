using Microsoft.AspNetCore.Mvc;
using RecipeCostCalculation.Domain.Models;
using RecipeCostCalculation.Service.Interfaces;

namespace RecipeCostCalculation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        public IActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel createProductModel)
        {
            var response = await _productService.Create(createProductModel);

            if (response.StatusCode == Domain.Enums.StatusCode.Success)
                return Ok(new {description = response.Description });

            return BadRequest(new { description = response.Description });
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsInFridge()
        {
            var response = await _productService.GetProductsInFridge();

            return Json(new {data = response.Data});
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductsInFridge(long id)
        {
            var response = await _productService.DeleteProductsInFridge(id);

            if (response.StatusCode == Domain.Enums.StatusCode.Success)
                return Ok(new { description = response.Description });

            return BadRequest(new { description = response.Description });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProductsInFridge(AvailableProductsModel model)
        {
            var response = await _productService.ChangeProductsInFridge(model);

            if (response.StatusCode == Domain.Enums.StatusCode.Success)
                return Ok(new { description = response.Description });

            return BadRequest(new { description = response.Description });
        }
    }
}

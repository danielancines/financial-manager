using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        //private ProductRepository _productRepository;
        //public ProductController(ProductRepository productRepository)
        //{
        //    this._productRepository = productRepository;
        //}

        //[HttpGet]
        //public async Task<ActionResult<IList<Product>>> Get()
        //{
        //    var products = await this._productRepository.Get();
        //    return Ok(products);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Post(Product product)
        //{
        //    var result = await this._productRepository.Add(product);

        //    return result ? Created("api/v1/product/1", product) : BadRequest();
        //}
    }

    public class Product
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
using FinancialManager.Data.Models;
using FinancialManager.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        private ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IList<Product>> Get()
        {
            var products = this._productRepository.Get();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            var result = this._productRepository.Add(product);
        
            return result ? Created("api/v1/product/1", product) : BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            return this._productRepository.Delete(id) ? Ok() : NotFound();
        }
    }
}
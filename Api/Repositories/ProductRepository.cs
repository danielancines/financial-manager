using FinancialManager.Api.Controllers;

namespace FinancialManager.Api.Repositories;

public class ProductRepository
{
    public List<Product> Products { get; init; } = new List<Product>();

    public async Task<IList<Product>> Get()
    {
        return this.Products;
    }

    public async Task<bool> Add(Product product)
    {
        this.Products.Add(product);
        return true;
    }
}

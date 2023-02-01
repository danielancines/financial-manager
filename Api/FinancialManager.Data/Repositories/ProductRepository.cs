using FinancialManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.Data.Repositories;

public class ProductRepository
{
    private FinancialManagerDbContext _context;
    public ProductRepository(FinancialManagerDbContext context)
    {
        this._context = context;
    }
    public IEnumerable<Product> Get()
    {
        return this._context.Products;
    }

    public bool Add(Product product)
    {
        this._context.Products.Add(product);
        return this._context.SaveChanges() > 0;
    }
    
    public bool Delete(Guid id)
    {
        var product = this._context.Products.FirstOrDefault(p=> p.Id.Equals(id));
        if (product == null)
            return false;
        
        var result = this._context.Products.Remove(product);
        if (result.State == EntityState.Deleted)
        {
            this._context.SaveChanges();
            return true;
        }
        return false;
    }
}   
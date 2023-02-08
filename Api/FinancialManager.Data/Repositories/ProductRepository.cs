using FinancialManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace FinancialManager.Data.Repositories;

public class ProductRepository
{
    private readonly IMongoCollection<Product> _productsCollection;
    //private FinancialManagerDbContext _context;
    public ProductRepository(FinancialBuddyDatabaseSettings financialBuddyDatabaseSettings)
    {
        var mongoClient = new MongoClient(financialBuddyDatabaseSettings.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(financialBuddyDatabaseSettings.DatabaseName);
        _productsCollection = mongoDatabase.GetCollection<Product>(financialBuddyDatabaseSettings.ProductsCollectionName);
    }
    public IEnumerable<Product> Get()
    {
        return this._productsCollection.Find(_ => true).ToEnumerable();
    }

    public bool Add(Product product)
    {
        this._productsCollection.InsertOne(product);
        return true;
    }
    
    public bool Delete(string id)
    {
        var product = this._productsCollection.Find(p=> p.Id == id).FirstOrDefault();
        if (product == null)
            return false;

        var result = this._productsCollection.DeleteOne(p => p.Id == id);
        return result.DeletedCount > 0;
    }
}   
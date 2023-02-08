using FinancialManager.Data.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinancialManager.Data.Repositories;

public class UserRepository
{
    private readonly IMongoCollection<User> _usersCollection;
    private FinancialManagerDbContext _context;
    public UserRepository(FinancialBuddyDatabaseSettings financialBuddyDatabaseSettings)
    {
        var mongoClient = new MongoClient(financialBuddyDatabaseSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(financialBuddyDatabaseSettings.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(financialBuddyDatabaseSettings.UsersCollectionName);
    }

    public User? GetByLogin(string login, string password)
    {
        return this._usersCollection.Find(u => u.Login == login && u.Password == password).FirstOrDefault();
    }
}
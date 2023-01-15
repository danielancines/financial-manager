using FinancialManager.Data.Models;

namespace FinancialManager.Data.Repositories;

public class UserRepository
{
    private FinancialManagerDbContext _context;
    public UserRepository(FinancialManagerDbContext context)
    {
        this._context = context;
    }
    public User? GetByLogin(string login, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
    }
}

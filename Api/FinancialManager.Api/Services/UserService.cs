using FinancialManager.Commons.Helpers;
using FinancialManager.Data.Models;
using FinancialManager.Data.Repositories;

namespace FinancialManager.Api.Services;

public class UserService
{
    private readonly UserRepository userRepository;

    public UserService(UserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public User? GetUser(string login, string password)
    {
        return this.userRepository.GetByLogin(login, CryptHelper.EncryptString(password));
    }
}

using FinancialManager.Api.Services;
using FinancialManager.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController
{
    private readonly TokenService tokenService;
    private readonly UserService userService;

    public AuthenticationController(TokenService tokenService, UserService userService)
    {
        this.tokenService = tokenService;
        this.userService = userService;
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult<dynamic> Authenticate(User user)
    {
        if (user == null || user.Login == string.Empty)
            return new UnauthorizedResult();

        var resultUser = this.userService.GetUser(user.Login, user.Password);
        if (resultUser == null)
            return new UnauthorizedResult();

        var token = this.tokenService.GenerateToken(user);
        return new
        {
            user = resultUser.Login,
            userName = $"{resultUser.Name} {resultUser.LastName}",
            token
        };
    }
}
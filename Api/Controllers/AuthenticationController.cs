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
    public async Task<ActionResult<dynamic>> Authenticate(User user)
    {
        if (user == null || user.Login != "daniel.ancines@gmail.com")
            return new BadRequestResult();

        var resultUser = this.userService.GetUser(user.Login, user.Password);
        if (resultUser == null)
            return new BadRequestResult();

        var token = this.tokenService.GenerateToken(user);
        return new
        {
            user = resultUser.Login,
            token
        };
    }
}
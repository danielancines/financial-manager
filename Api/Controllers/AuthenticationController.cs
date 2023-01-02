using FinancialManager.Api.Models;
using FinancialManager.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinancialManager.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController
{
    private TokenService _tokenService;
    public AuthenticationController(TokenService tokenService)
    {
        this._tokenService = tokenService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate(User user)
    {
        if (user == null || user.Login != "daniel.ancines@gmail.com")
            return new BadRequestResult();

        var token = this._tokenService.GenerateToken(user);
        return new
        {
            user = "daniel.ancines@gmail.com",
            token
        };
    }
}
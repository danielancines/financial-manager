using System;
using FinancialManager.Api.Services;
using FinancialManager.Api.Services.Types;
using FinancialManager.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/investment")]
public class InvestmentController : ControllerBase
{
    InvestmentService _investmentService;

    public InvestmentController(InvestmentService investmentService)
    {
        this._investmentService = investmentService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<InvestmentOption>>> Get()
    {
        var sessionToken = await this._investmentService.GetNFSession();
        var investments = await this._investmentService.GetInvestments(sessionToken);
        var selic = await this._investmentService.GetBcBRateTaxesAsync(BcbIndicatorsType.Selic);
        var ipca = await this._investmentService.GetBcBRateTaxesAsync(BcbIndicatorsType.IPCA);

        investments.ForEach(i =>
        {
            i.SelicRate = selic;
            i.IpcaRate = ipca;
        });

        return Ok(investments);
    }
}
using System;
using System.Net.Http.Headers;
using System.Text.Json;
using FinancialManager.Api.Services.Types;
using FinancialManager.Commons.Core;
using FinancialManager.Data.Models;

namespace FinancialManager.Api.Services;

public class InvestmentService
{
    HttpClient _httpClient;

    public InvestmentService()
    {
        this._httpClient = new HttpClient();
    }

    public async Task<double> GetBcBRateTaxesAsync(BcbIndicatorsType indicatorType)
    {
        try
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.30.1");
            this._httpClient.DefaultRequestHeaders.Add("Host", "api.bcb.gov.br");
            var response = await this._httpClient.GetAsync(this.GetUri(indicatorType));

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var element = JsonSerializer.Deserialize<JsonElement>(data);
                element = element.EnumerateArray().FirstOrDefault();
                element.TryGetProperty("valor", out var selicRateElement);

                return double.Parse(selicRateElement.GetString().Replace('.',',')) / 100;
            }
            else
                return 0;

        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public async Task<string> GetNFSession()
    {
        var body = JsonContent.Create<dynamic>(new
        {
            tipo = "NAVEGADOR",
            email = Environment.GetEnvironmentVariable("nf-email"),
            senha = Environment.GetEnvironmentVariable("nf-pwd"),
            imei = Environment.GetEnvironmentVariable("nf-imei")
        });

        this._httpClient.DefaultRequestHeaders.Clear();
        var response = await this._httpClient.PostAsync("https://portal.novafutura.com.br/api-mobile/api/TokenRecorrente/LoginImei", body);

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadFromJsonAsync<JsonElement>();
            if (!responseData.TryGetProperty("SESSAO", out var session))
                return string.Empty;

            return session.GetString();
        }
        else
        {
            return string.Empty;
        }
    }

    public async Task<List<InvestmentOption>> GetInvestments(string token)
    {   
        var body = JsonContent.Create<dynamic>(new
        {
            aba = "CDB",
            ativo = "",
            emissor = "",
            indice = "",
            ir = "",
            liquidez = "",
            minimo = 0,
            taxa = 0,
            prazo = 0
        });

        this._httpClient.DefaultRequestHeaders.Clear();
        this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await this._httpClient.PostAsync("https://portal.novafutura.com.br/portal/api/TRF200_01Portal", body);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<InvestmentOption>>(options: new JsonSerializerOptions()
            {
                PropertyNamingPolicy = new InvestmentsNamePolicy()
            });
        }
        else
            return new List<InvestmentOption>();
    }

    string GetUri(BcbIndicatorsType indicatorType) => indicatorType switch
    {
        BcbIndicatorsType.IPCA => "http://api.bcb.gov.br/dados/serie/bcdata.sgs.10844/dados/ultimos/1?formato=json",
        BcbIndicatorsType.Selic => "http://api.bcb.gov.br/dados/serie/bcdata.sgs.4189/dados/ultimos/1?formato=json",
        _ => throw new ArgumentOutOfRangeException(nameof(indicatorType), "Indicator Type Not Found")
    };
}




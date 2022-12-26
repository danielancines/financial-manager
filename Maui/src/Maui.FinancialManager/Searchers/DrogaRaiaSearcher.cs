using System.Text;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Resources;
using Maui.FinancialManager.Searchers.Base;
using Maui.FinancialManager.Serializers;

namespace Maui.FinancialManager.Searchers;

public class DrogaRaiaSearcher : IMedicineSearcher
{
    const string URL = @"https://app-api-m2-prod.drogaraia.com.br/graphql";

    public async Task<IEnumerable<Medicine>> SearchAsync(string searchTerm)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "5f308895c59fadb0b9ed43341c6eb33e41e78394d3ca970c5a285e91d25bc9cd");

        var content = new StringContent(SearchUrls.DrogaRaia.Replace("!searchTerm!", searchTerm), Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(string.Format(URL, searchTerm), content);

        if (response.IsSuccessStatusCode)
        {
            return DrogaraiaSerializer.Deserialize(await response.Content.ReadAsStringAsync());
        }
        else
        {
            return new List<Medicine>();
        }
    }
}


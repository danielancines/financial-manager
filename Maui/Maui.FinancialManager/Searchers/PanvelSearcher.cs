using Maui.FinancialManager.Models;
using Maui.FinancialManager.Searchers.Base;
using Maui.FinancialManager.Serializers;

namespace Maui.FinancialManager.Searchers;

public class PanvelSearcher : IMedicineSearcher
{
    readonly string URL = "https://app.grupodimedservices.com.br/prod/app-bff-panvel/v1/search/autocomplete?searchTerm={0}";


    public async Task<IEnumerable<Medicine>> SearchAsync(string searchTerm)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("app-token", "3JWhVMiCENtU");
        var response = await httpClient.GetAsync(string.Format(URL, searchTerm));

        if (response.IsSuccessStatusCode)
        {
            return PanvelSerializer.Deserialize(await response.Content.ReadAsStringAsync());
        }
        else
        {
            return new List<Medicine>();
        }
    }
}


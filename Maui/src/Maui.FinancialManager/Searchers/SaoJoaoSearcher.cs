﻿using Maui.FinancialManager.Models;
using Maui.FinancialManager.Searchers.Base;
using Maui.FinancialManager.Serializers;

namespace Maui.FinancialManager.Searchers;

public class SaoJoaoSearcher : IMedicineSearcher
{
    const string URL = @"https://apiappprd.saojoaofarmacias.com.br/api/v2/products/linx?terms={0}";

    public async Task<IEnumerable<Medicine>> SearchAsync(string searchTerm)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(string.Format(URL, searchTerm));

        if (response.IsSuccessStatusCode)
        {
            return SaoJoaoSerializer.Deserialize(await response.Content.ReadAsStringAsync());

        }
        else
        {
            return new List<Medicine>();
        }
    }
}


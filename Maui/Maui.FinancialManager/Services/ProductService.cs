using System;
using System.Text.Json;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Services.Base;

namespace Maui.FinancialManager.Services;

public class ProductsService : BaseService
{
    public async Task<IEnumerable<Product>> Get()
    {
        var products = new List<Product>();
        var httpClient = this.GetClient();
        var response = await httpClient.GetAsync("http://localhost:5095/api/v1/product");

        if (response.IsSuccessStatusCode)
        {
            products = JsonSerializer.Deserialize<List<Product>>(await response.Content.ReadAsStringAsync());
        }

        return products;
    }
}


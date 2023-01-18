using System.Text.Json;
using Maui.FinancialManager.Models;

namespace Maui.FinancialManager.Serializers;

public class DrogaraiaSerializer
{
    public static List<Medicine> Deserialize(string rawResult)
    {
        var medicines = new List<Medicine>();

        JsonElement search;
        if (!JsonSerializer.Deserialize<JsonElement>(rawResult).TryGetProperty("search", out search))
            return medicines;

        JsonElement products;
        if (!search.TryGetProperty("products", out products))
            return medicines;

        foreach (var item in products.EnumerateArray())
        {
            var hasStock = item.GetProperty("availability").GetProperty("hasStock").GetBoolean();
            if (!hasStock)
                continue;

            var newMedicine = new Medicine();

            newMedicine.Name = item.GetProperty("name").GetString();

            if (item.GetProperty("oldPrice").ValueKind != JsonValueKind.Null)
                newMedicine.OldPrice = (float)item.GetProperty("oldPrice").GetProperty("value").GetDecimal();

            if (item.GetProperty("price").ValueKind != JsonValueKind.Null)
                newMedicine.Price = (float)item.GetProperty("price").GetProperty("value").GetDecimal();

            if (item.GetProperty("packageQty").ValueKind != JsonValueKind.Null)
                newMedicine.PackageQuantity = item.GetProperty("packageQty").GetString();

            newMedicine.DrugStore = "Droga Raia";
            newMedicine.Thumbnail = item.GetProperty("image").GetString();

            medicines.Add(newMedicine);
        }

        return medicines;
    }
}


using System.Text.Json;
using Maui.FinancialManager.Models;

namespace Maui.FinancialManager.Serializers;

public class PanvelSerializer
{
    public static List<Medicine> Deserialize(string rawResult)
    {
        var medicines = new List<Medicine>();

        JsonElement items;
        if (!JsonSerializer.Deserialize<JsonElement>(rawResult).TryGetProperty("items", out items))
            return medicines;

        foreach (var item in items.EnumerateArray())
        {
            var newMedicine = new Medicine();
            newMedicine.Thumbnail = new UriImageSource() { Uri = new Uri(item.GetProperty("image").GetString()) };
            newMedicine.OldPrice = (float)item.GetProperty("originalPrice").GetDecimal();
            newMedicine.Price = (float)item.GetProperty("finalPrice").GetDecimal();
            newMedicine.Name = item.GetProperty("productFullName").GetString();
            newMedicine.DrugStore = "Panvel";

            medicines.Add(newMedicine);
        }

        return medicines;
    }
}


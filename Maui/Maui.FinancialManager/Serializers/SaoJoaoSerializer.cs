using System.Text.Json;
using Maui.FinancialManager.Models;

namespace Maui.FinancialManager.Serializers;

public class SaoJoaoSerializer
{
    public static List<Medicine> Deserialize(string rawResult)
    {
        var medicines = new List<Medicine>();

        JsonElement data;
        if (!JsonSerializer.Deserialize<JsonElement>(rawResult).TryGetProperty("data", out data))
            return medicines;

        if (data.ValueKind != JsonValueKind.Array)
            return medicines;

        foreach (var item in data.EnumerateArray())
        {
            var newMedicine = new Medicine();
            foreach (var image in item.GetProperty("imagens").EnumerateArray())
                newMedicine.Thumbnail = image.GetString();

            newMedicine.Price = (float)item.GetProperty("precoDe").GetDecimal();

            JsonElement priceFor = item.GetProperty("precoPor");
            if (priceFor.ValueKind != JsonValueKind.Null)
                newMedicine.Price = (float)priceFor.GetDecimal();

            foreach (var promotion in item.GetProperty("promocoes").EnumerateArray())
            {
                if (promotion.TryGetProperty("valueFrom", out var valueFrom) && valueFrom.ValueKind != JsonValueKind.Null)
                    newMedicine.OldPrice = (float)valueFrom.GetDecimal();

                if (promotion.TryGetProperty("valueTo", out var valueTo) && valueFrom.ValueKind != JsonValueKind.Null)
                    newMedicine.Price = (float)valueFrom.GetDecimal();

                if (promotion.TryGetProperty("dtFinal", out var dtFinal) && valueFrom.ValueKind != JsonValueKind.Null)
                    newMedicine.ExpireDate = dtFinal.GetDateTime();
            }

            newMedicine.Name = item.GetProperty("nomeProduto").GetString();
            newMedicine.DrugStore = "São João";

            medicines.Add(newMedicine);
        }

        return medicines;
    }
}


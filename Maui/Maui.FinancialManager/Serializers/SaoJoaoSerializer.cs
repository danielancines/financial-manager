using System.Text.Json;
using Maui.FinancialManager.Extensions;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Primitives;
using Maui.FinancialManager.Serializers.Base;

namespace Maui.FinancialManager.Serializers;

public class SaoJoaoSerializer : BaseSerializer<Medicine>
{
    public override IList<Medicine> GetItems(JsonElement rootElement)
    {
        var medicines = new List<Medicine>();

        foreach (var item in rootElement.Value<JsonElement.ArrayEnumerator>("data", JsonValueTypes.Array))
        {
            var newMedicine = new Medicine();
            foreach (var image in item.Value<JsonElement.ArrayEnumerator>("imagens", JsonValueTypes.Array))
                newMedicine.Thumbnail = image.GetString();

            newMedicine.Price = item.Value<float>("precoDe", JsonValueTypes.Decimal);

            var newPrice = item.Value<float>("precoPor", JsonValueTypes.Decimal);
            if (newPrice > 0)
                newMedicine.Price = newPrice;

            foreach (var promotion in item.GetProperty("promocoes").EnumerateArray())
            {
                newMedicine.OldPrice = promotion.Value<float>("valueFrom", JsonValueTypes.Decimal);

                newPrice = promotion.Value<float>("valueTo", JsonValueTypes.Decimal);
                if (newPrice > 0)
                    newMedicine.Price = newPrice;

                newMedicine.ExpireDate = promotion.Value<DateTime>("dtFinal", JsonValueTypes.DateTime);
            }

            newMedicine.Name = item.Value<string>("nomeProduto", JsonValueTypes.String);
            newMedicine.DrugStore = "São João";
            medicines.Add(newMedicine);
        }

        return medicines;
    }
}


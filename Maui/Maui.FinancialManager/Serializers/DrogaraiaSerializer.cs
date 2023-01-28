using System.Text.Json;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Extensions;
using Maui.FinancialManager.Primitives;
using Maui.FinancialManager.Serializers.Base;

namespace Maui.FinancialManager.Serializers;

public class DrogaraiaSerializer : BaseSerializer<Medicine>
{
    public override IList<Medicine> GetItems(JsonElement rootElement)
    {
        var medicines = new List<Medicine>();

        rootElement = rootElement.Value<JsonElement>("data", JsonValueTypes.JsonElement);
        if (rootElement.ValueKind == JsonValueKind.Null)
            return medicines;

        var search = rootElement.Value<JsonElement>("search", JsonValueTypes.JsonElement);
        if (search.ValueKind == JsonValueKind.Null)
            return medicines;

        foreach (var item in search.Value<JsonElement.ArrayEnumerator>("products", JsonValueTypes.Array))
        {
            var hasStock = item.Value<JsonElement>("availability", JsonValueTypes.JsonElement).Value<bool>("hasStock", JsonValueTypes.Boolean);
            if (!hasStock)
                continue;

            var newMedicine = new Medicine();

            newMedicine.Name = item.Value<string>("name", JsonValueTypes.String);

            if (item.GetProperty("oldPrice").ValueKind != JsonValueKind.Null)
                newMedicine.OldPrice = item.Value<JsonElement>("oldPrice", JsonValueTypes.JsonElement).Value<float>("value", JsonValueTypes.Decimal);

            if (item.GetProperty("price").ValueKind != JsonValueKind.Null)
                newMedicine.Price = item.Value<JsonElement>("price", JsonValueTypes.JsonElement).Value<float>("value", JsonValueTypes.Decimal);

            if (item.GetProperty("packageQty").ValueKind != JsonValueKind.Null)
                newMedicine.PackageQuantity = item.Value<string>("packageQty", JsonValueTypes.String);

            if (item.GetProperty("description").ValueKind != JsonValueKind.Null)
                newMedicine.Description = item.Value<string>("description", JsonValueTypes.String);

            foreach (var image in item.Value<JsonElement.ArrayEnumerator>("gallery", JsonValueTypes.Array))
                newMedicine.Images.Add(image.GetString());

            newMedicine.DrugStore = "Droga Raia";
            newMedicine.Thumbnail = item.Value<string>("image", JsonValueTypes.String);

            medicines.Add(newMedicine);
        }

        return medicines;
    }
}
using System.Text.Json;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Extensions;
using Maui.FinancialManager.Primitives;
using Maui.FinancialManager.Serializers.Base;

namespace Maui.FinancialManager.Serializers;

public class PanvelSerializer : BaseSerializer<Medicine>
{
    public override IList<Medicine> GetItems(JsonElement rootElement)
    {
        var medicines = new List<Medicine>();

        foreach (var item in rootElement.Value<JsonElement.ArrayEnumerator>("items", JsonValueTypes.Array))
        {
            var newMedicine = new Medicine();
            newMedicine.Thumbnail = new UriImageSource() { Uri = new Uri(item.GetProperty("image").GetString()) };
            newMedicine.OldPrice = item.Value<float>("originalPrice", JsonValueTypes.Decimal);
            newMedicine.Price = item.Value<float>("finalPrice", JsonValueTypes.Decimal);
            newMedicine.Name = item.GetProperty("productFullName").GetString();
            newMedicine.DrugStore = "Panvel";

            medicines.Add(newMedicine);
        }

        return medicines;
    }
}


using System;
using System.Text.Json;

namespace Maui.FinancialManager.Serializers.Base;

public abstract class BaseSerializer<T>
{
    public IList<T> Deserialize(string rawString)
    {
        try
        {
            var result = new List<T>();

            JsonElement data = JsonSerializer.Deserialize<JsonElement>(rawString);
            if (data.ValueKind == JsonValueKind.Null)
                return result;

            return this.GetItems(data);
        }
        catch (Exception ex)
        {
            Shell.Current.DisplayAlert("Error", $"Error at Deserialize: {ex.Message} - {ex.InnerException?.Message}", "Ok");
            return default(IList<T>);
        }
    }

    public abstract IList<T> GetItems(JsonElement rootElement);
}


using System;
using System.Text.Json;

namespace Maui.FinancialManager.Serializers.Base;

public abstract class BaseSerializer<T>
{
    public IList<T> Deserialize(string rawString)
    {
        var result = new List<T>();

        JsonElement data = JsonSerializer.Deserialize<JsonElement>(rawString);
        if (data.ValueKind == JsonValueKind.Null)
            return result;

        return this.GetItems(data);
    }

    public abstract IList<T> GetItems(JsonElement rootElement);
}


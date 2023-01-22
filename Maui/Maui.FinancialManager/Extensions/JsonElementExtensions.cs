using System;
using System.Text.Json;
using Maui.FinancialManager.Primitives;

namespace Maui.FinancialManager.Extensions;

public static class JsonElementExtensions
{
    public static T Value<T>(this JsonElement element, string propertyName, JsonValueTypes valueType)
    {
        if (!element.TryGetProperty(propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            return default(T);

        switch (valueType)
        {
            case JsonValueTypes.DateTime:
                return (T)Convert.ChangeType(property.GetDateTime(), typeof(T));
            case JsonValueTypes.Decimal:
                return (T)Convert.ChangeType(property.GetDecimal(), typeof(T));
            case JsonValueTypes.String:
                return (T)Convert.ChangeType(property.GetString(), typeof(T));
            case JsonValueTypes.Array:
                return (T)Convert.ChangeType(property.EnumerateArray(), typeof(T));
            case JsonValueTypes.JsonElement:
                return (T)Convert.ChangeType(property, typeof(T));
            case JsonValueTypes.Boolean:
                return (T)Convert.ChangeType(property.GetBoolean(), typeof(T));
        }

        return default(T);
    }
}


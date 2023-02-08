using System;
using System.Text.Json.Serialization;

namespace Maui.FinancialManager.Models;

public class Product
{
    public string Barcode { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}


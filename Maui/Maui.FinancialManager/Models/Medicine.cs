using System;
namespace Maui.FinancialManager.Models;

public class Medicine
{
    public string Name { get; set; }

    public float Price { get; set; }

    public ImageSource Thumbnail { get; set; }

    public List<ImageSource> Images { get; private set; } = new List<ImageSource>();

    public string DrugStore { get; set; }

    public float OldPrice { get; set; }

    public string PackageQuantity { get; set; }

    public string Description { get; set; }

    public DateTime ExpireDate { get; set; }

    public override string ToString()
    {
        return this.Price.ToString();
    }
}


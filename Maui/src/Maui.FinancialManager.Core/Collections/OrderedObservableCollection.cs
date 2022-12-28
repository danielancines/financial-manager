using System.Collections.ObjectModel;
using Maui.FinancialManager.Core.Collections.Specialized;

namespace Maui.FinancialManager.Core.Collections;

public class OrderedObservableCollection<T> : ObservableCollection<T>
{
    public OrderedObservableCollection(string orderBy, OrderedPropertyType propertyType) : base()
    {
        this.OrderBy = orderBy;
        this.PropertyType = propertyType;
    }
    public string OrderBy { get; init; }

    public OrderedPropertyType PropertyType { get; init; }

    public int AddOrdered(T item)
    {
        if (string.IsNullOrEmpty(this.OrderBy))
            return -1;

        var index = this.GetNextItemIndex(item);
        this.Insert(index, item);

        return index;
    }

    private int GetNextItemIndex(T newItem)
    {
        switch (this.PropertyType)
        {
            case OrderedPropertyType.Float:
                return this.ProcessFloat(newItem);
            default:
                return this.Items.Count;
        }
    }

    private int ProcessFloat(T newItem)
    {
        foreach (var item in this.Items)
            if (this.ParseValueToFloat(item) > this.ParseValueToFloat(newItem))
                return this.Items.IndexOf(item);

        return this.Items.Count;
    }

    private float ParseValueToFloat(T item)
    {
        try
        {
            var property = item.GetType().GetProperty(this.OrderBy);
            return (float)property.GetValue(item);
        }
        catch
        {
            return 0;
        }
    }
}


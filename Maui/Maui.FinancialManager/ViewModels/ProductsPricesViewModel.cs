using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.FinancialManager.Core.Collections;
using Maui.FinancialManager.Core.Collections.Specialized;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Services;

namespace Maui.FinancialManager.ViewModels;

public partial class ProductsPricesViewModel : ObservableObject, IQueryAttributable
{
    private readonly ProductsService ProductsService;

    public ProductsPricesViewModel(ProductsService productsService)
    {
        this.ProductsService = productsService;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        this.ProductBarCode = query["productBarCode"].ToString();
    }

    [RelayCommand]
    async void OpenBarcodeReader()
    {
        this.Products.Clear();
        var products = await this.ProductsService.Get();
        foreach (var product in products)
        {
            this.Products.AddOrdered(product);
        }
        //Shell.Current.GoToAsync("/barcodereader");
    }

    [ObservableProperty]
    string productBarCode;

    public OrderedObservableCollection<Product> Products { get; } = new OrderedObservableCollection<Product>("Name", OrderedPropertyType.String);
}


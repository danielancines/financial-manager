using ZXing.Net.Maui;
using Maui.FinancialManager.ViewModels;

namespace Maui.FinancialManager.Views;

public partial class ProductsPricesView : ContentPage
{
    public ProductsPricesView(ProductsPricesViewModel productsPricesViewModel)
    {
        InitializeComponent();
        this.BindingContext = productsPricesViewModel;

        //cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        //{
        //    Formats = BarcodeFormats.OneDimensional,
        //    AutoRotate = false,
        //    Multiple = false,
        //    TryHarder = true
        //};
    }

    //void cameraBarcodeReaderView_BarcodesDetected(System.Object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    //{
    //    MainThread.BeginInvokeOnMainThread(() =>
    //    {
    //        if (products.TryGetValue(e.Results[0].Value, out string barcode))
    //            this.ResultLabel.Text = barcode;
    //        else
    //            this.ResultLabel.Text = "Product not found";
    //    });
    //}
}

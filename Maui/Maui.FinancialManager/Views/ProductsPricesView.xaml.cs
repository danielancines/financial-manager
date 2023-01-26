using ZXing.Net.Maui;

namespace Maui.FinancialManager.Views;

public partial class ProductsPricesView : ContentPage
{
    Dictionary<string, string> products = new Dictionary<string, string>() { { "7622210570376", "Trident x Senser Melancia Ming" }, { "7891000061190", "Nescau 200g" } };
    public ProductsPricesView()
    {
        InitializeComponent();
        //cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        //{
        //    Formats = BarcodeFormats.OneDimensional,
        //    AutoRotate = false,
        //    Multiple = false,
        //    TryHarder = true
        //};
    }

    void cameraBarcodeReaderView_BarcodesDetected(System.Object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (products.TryGetValue(e.Results[0].Value, out string barcode))
                this.ResultLabel.Text = barcode;
            else
                this.ResultLabel.Text = "Product not found";
        });
    }
}

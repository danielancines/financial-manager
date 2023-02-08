using ZXing.Net.Maui;

namespace Maui.FinancialManager.Views;

public partial class BarcodeReaderView : ContentPage
{
    public BarcodeReaderView()
    {
        InitializeComponent();
    }

    void cameraBarcodeReaderView_BarcodesDetected(System.Object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        Shell.Current.GoToAsync("..", new Dictionary<string, object> { { "productBarCode", e.Results[0].Value } });
    }

    void ContentPage_Loaded(System.Object sender, System.EventArgs e)
    {
        this.CameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = false,
            Multiple = false,
            TryHarder = true
        };
    }
}
    
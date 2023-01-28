using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.FinancialManager.Core.Collections;
using Maui.FinancialManager.Core.Collections.Specialized;
using Maui.FinancialManager.Helpers;
using Maui.FinancialManager.Models;
using Maui.FinancialManager.Searchers.Base;

namespace Maui.FinancialManager.ViewModels;

public partial class MedicinePricesViewModel : ObservableObject
{
    readonly List<IMedicineSearcher> MedicineSearchers = new();
    public OrderedObservableCollection<Medicine> Medicines { get; set; } = new("Price", OrderedPropertyType.Float);
    public string SearchTerm { get; set; }

    public MedicinePricesViewModel()
    {
        var searchers = DependencyContainerHelper.GetServices<IMedicineSearcher>();
        this.MedicineSearchers.AddRange(searchers);
    }

    public string FooterAppInfo { get; } = $"{AppInfo.Current.Name} - {AppInfo.Version}";

    [ObservableProperty]
    bool loadingData;
    [ObservableProperty]
    Medicine selectedMedicine;

    partial void OnSelectedMedicineChanged(Medicine value)
    {
        if (value == null)
            return;

        _ = Shell.Current.GoToAsync("medicinedetail", new Dictionary<string, object> { { "medicine", value } });
        this.SelectedMedicine = null;
    }

    [RelayCommand]
    void OpenMedicineDetails()
    {

    }

    [RelayCommand]
    async void Search()
    {
        this.Medicines.Clear();

        var tasks = new List<Task>();

        this.LoadingData = true;
        foreach (var searcher in this.MedicineSearchers)
            tasks.Add(this.Search(searcher));

        await Task.WhenAll(tasks);

        this.LoadingData = false;
    }

    async Task Search(IMedicineSearcher searcher)
    {
        try
        {
            var medicines = await searcher.SearchAsync(this.SearchTerm);
            if (medicines != null)
                foreach (var medicine in medicines)
                    this.Medicines.AddOrdered(medicine);

        }
        catch (Exception ex)
        {
            _= Shell.Current.DisplayAlert("Error", $"Error at ViewModel: {ex.Message} - {searcher} - {ex.InnerException?.Message}", "Ok");
        }
    }
}


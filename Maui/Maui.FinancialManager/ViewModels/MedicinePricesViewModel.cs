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
    private bool loadingData;

    [RelayCommand]
    private void SelectionMedicine(Medicine medicine)
    {
        //var shellNavigation = new ShellNavigationState("medicinedetail");
        _ = Shell.Current.GoToAsync("medicinedetail", new Dictionary<string, object> { { "medicine", medicine } });
    }

    [RelayCommand]
    private async void Search()
    {
        this.Medicines.Clear();

        var tasks = new List<Task>();

        this.LoadingData = true;
        foreach (var searcher in this.MedicineSearchers)
            tasks.Add(this.Search(searcher));

        await Task.WhenAll(tasks);

        this.LoadingData = false;
    }

    private async Task Search(IMedicineSearcher searcher)
    {
        var medicines = await searcher.SearchAsync(this.SearchTerm);
        foreach (var medicine in medicines)
            this.Medicines.AddOrdered(medicine);
    }
}


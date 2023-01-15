using Maui.FinancialManager.Models;

namespace Maui.FinancialManager.Searchers.Base;

public interface IMedicineSearcher
{
    Task<IEnumerable<Medicine>> SearchAsync(string searchTerm);
}


namespace FinancialManager.Data.Models;

public class FinancialBuddyDatabaseSettings
{
    public readonly string? ConnectionString;
    public readonly string? DatabaseName;
    public string? UsersCollectionName { get; init; }
    public string? ProductsCollectionName { get; init; }

    public FinancialBuddyDatabaseSettings(string? connectionString, string? databaseName)
    {
        this.ConnectionString = connectionString;
        this.DatabaseName = databaseName;
    }
}
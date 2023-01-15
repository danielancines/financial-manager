namespace FinancialManager.Data.Models;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Roles { get; set; }
    public bool Active { get; set; }
}

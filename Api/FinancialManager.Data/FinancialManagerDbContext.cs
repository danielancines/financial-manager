using FinancialManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.Data;

public class FinancialManagerDbContext : DbContext
{
    public FinancialManagerDbContext()
    {
    }

    public FinancialManagerDbContext(DbContextOptions<FinancialManagerDbContext> options)
    : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }
}
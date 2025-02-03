using Microsoft.EntityFrameworkCore;
using StageEs1.Data;

public class AziendaDbContext : DbContext
{
    public AziendaDbContext(DbContextOptions<AziendaDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
}

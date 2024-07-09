using Microsoft.EntityFrameworkCore;

namespace AspireStarterApplicaitonPlayground.ApiService.Data;

public class TestDataDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TestEfTable> TestEfTable { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestEfTable>().Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        base.OnModelCreating(modelBuilder);
    }
}

public class TestEfTable
{
    public int Id { get; set; }
    public string Text { get; set; }
}
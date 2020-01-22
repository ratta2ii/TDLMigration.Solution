using Microsoft.EntityFrameworkCore;

namespace TDLMigration.Models
{
  public class TDLMigrationContext : DbContext
  {
    public virtual DbSet<Category> CategoriesTable { get; set; }
    public DbSet<Item> ItemsTable { get; set; }
    public DbSet<CategoryItem> CategoryItemJoinedTable { get; set; }

    public TDLMigrationContext(DbContextOptions options) : base(options) { }
  }
}
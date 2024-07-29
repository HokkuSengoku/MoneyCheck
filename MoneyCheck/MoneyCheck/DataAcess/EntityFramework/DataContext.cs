using Microsoft.EntityFrameworkCore;
using MoneyCheck.Models;

namespace MoneyCheck.DataAcess.EntityFramework;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions options)
        : base(options)
    {
        SavingChanges += (sender, args) =>
        {
            Console.WriteLine($"Saving changes for {((DbContext)sender).
                Database.GetConnectionString()}");
        } ;
        SavedChanges += (sender, args) =>
        {
            Console.WriteLine($"Saved {args.EntitiesSavedCount} entities");
        } ;
        SaveChangesFailed += (sender, args) =>
        {
// Сгенерировано исключение.
            Console.WriteLine($"An exception occurred! {args.Exception.Message} entities)");
        };
    }
    
    public DbSet<Account> AccountModels { get; set; }
    public DbSet<Category> CategoriesEnumerable { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
// Обращения к Fluent API.
       

        /* modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Account>().ToTable("Accounts");
        modelBuilder.Entity<Category>().ToTable("Categories");
        OnModelCreatingPartial(modelBuilder);*/
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
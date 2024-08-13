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


        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users", "MoneyCheck");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(15);
            entity.Property(e => e.Balance)
                .HasDefaultValue(0);
            entity.HasMany(e => e.UserAccounts)
                .WithOne(a => a.UserNavigation)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersAccount_Users_UserId");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories", "MoneyCheck");
            entity.HasIndex(e => e.AccountId, "Category_AccountId")
                .IsUnique();
            entity.HasMany(op => op.CategoryOperations)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryOperations_Category_CategoryId");
        });
        
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Accounts", "MoneyCheck");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AccountName)
                .IsRequired()
                .HasMaxLength(15);
            entity.Property(e => e.AccountBalance)
                .IsRequired()
                .HasDefaultValue(0);
            entity.HasMany(c => c.AccountCategories)
                .WithOne(a => a.Account)
                .HasForeignKey(c => c.AccountId);
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.ToTable("Operations", "MoneyCheck");
            entity.HasKey(e => e.Id);
        });
        

    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
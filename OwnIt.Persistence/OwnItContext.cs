using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OwnIt.Domain.Models;

namespace OwnIt.Persistence;

public class OwnItContext : DbContext
{
    public OwnItContext(DbContextOptions<OwnItContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warning => warning.Ignore(CoreEventId.MultipleNavigationProperties));
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Category

        modelBuilder.Entity<Category>()
            .ToTable("Categories")
            .HasKey(c => c.Id);
        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Category>()
            .Property(c => c.Type)
            .IsRequired();

        // PaymentMethod

        modelBuilder.Entity<PaymentMethod>()
            .ToTable("PaymentMethods")
            .HasKey(pm => pm.Id);
        modelBuilder.Entity<PaymentMethod>()
            .Property(pm => pm.Name)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<PaymentMethod>()
            .Property(pm => pm.Type)
            .IsRequired();
        modelBuilder.Entity<PaymentMethod>()
            .Property(pm => pm.Limit)
            .HasColumnType("decimal")
            .IsRequired();
        modelBuilder.Entity<PaymentMethod>()
            .Property(pm => pm.DueDay)
            .IsRequired();

        // Transaction

        modelBuilder.Entity<Transaction>()
            .ToTable("Transactions")
            .HasKey(pm => pm.Id);
        modelBuilder.Entity<Transaction>()
            .Property(pm => pm.Amount)
            .HasColumnType("decimal")
            .IsRequired();

        // Inserts

        modelBuilder.Entity<PaymentMethod>()
            .HasData(new PaymentMethod()
            {
                Id = Guid.NewGuid(),
                Name = "Cartão de Credito",
                Limit = 5000,
                DueDay = 10,
                Type = PaymentMethodType.Card
            });
        modelBuilder.Entity<PaymentMethod>()
            .HasData(new PaymentMethod()
            {
                Id = Guid.NewGuid(),
                Name = "Vale Alimentação",
                Limit = 1000,
                DueDay = 10,
                Type = PaymentMethodType.FoodCard
            });
        modelBuilder.Entity<Category>()
            .HasData(new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Alimentação",
                Type = CategoryType.Food
            });
        modelBuilder.Entity<Category>()
            .HasData(new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Gasolina",
                Type = CategoryType.Car
            });
        modelBuilder.Entity<Category>()
            .HasData(new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Luz",
                Type = CategoryType.Monthly
            });
    }
}

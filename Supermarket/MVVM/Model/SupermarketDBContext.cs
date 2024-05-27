using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.MVVM.Model
{
    public class SupermarketDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Distributor> Distributors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<ProductReceipt> ProductReceipts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-25PUGFD\MSSQLSERVER02;Database=Supermarket;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<Distributor>().HasIndex(d => d.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Barcode).IsUnique();
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasOne(p => p.Distributor).WithMany(d => d.Products).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Stock>().HasOne(s => s.Product).WithMany(p => p.Stocks).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Stock>().Property(s => s.AcquisitionPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Stock>().Property(s => s.SalePrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Receipt>().HasOne(r => r.Cashier).WithMany(u => u.Receipts).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Receipt>().Property(r => r.Value).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<ProductReceipt>(entity =>
            {
                // Define composite primary key
                entity.HasKey(pr => new { pr.ProductId, pr.ReceiptId });

                // Relationship with Product
                entity.HasOne(pr => pr.Product)
                      .WithMany(p => p.ProductReceipts)
                      .HasForeignKey(pr => pr.ProductId)
                      .OnDelete(DeleteBehavior.Restrict); // or appropriate delete behavior

                // Relationship with Receipt
                entity.HasOne(pr => pr.Receipt)
                      .WithMany(r => r.ProductReceipts)
                      .HasForeignKey(pr => pr.ReceiptId)
                      .OnDelete(DeleteBehavior.Restrict); // or appropriate delete behavior
            });
            modelBuilder.Entity<ProductReceipt>().Property(pr => pr.Subtotal).HasColumnType("decimal(18,4)");
        }
    }
}

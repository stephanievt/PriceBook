using Microsoft.EntityFrameworkCore;

namespace PriceBook_Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Store> Store { get; set; }

        public DbSet<Unit> Unit { get; set; }

        public DbSet<UnitType> UnitType { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<ItemCostRecord> ItemCostRecord { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            PriceBookDataConfig priceBookDataConfig = new PriceBookDataConfig();
            optionsBuilder.UseSqlServer(priceBookDataConfig.ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SCHEMA
            modelBuilder.Entity<Item>()
                .HasIndex(i => new { i.Name })
                .IsUnique();
            modelBuilder.Entity<Category>()
                .HasIndex(c => new { c.Name })
                .IsUnique();
            modelBuilder.Entity<Store>()
                .HasIndex(s => s.Name)
                .IsUnique();
            modelBuilder.Entity<UnitType>().HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<Unit>().HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<UnitType>()
                .HasMany(e => e.Units)
                .WithOne(e => e.UnitType)
                .HasForeignKey(e => e.UnitTypeId)
                .IsRequired();

            
        }

        
    }
}

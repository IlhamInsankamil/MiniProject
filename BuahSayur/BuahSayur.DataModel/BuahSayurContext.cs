namespace BuahSayur.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BuahSayurContext : DbContext
    {
        public BuahSayurContext()
            : base("name=BuahSayurContext")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.Province_Code)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.City_Code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.City_Code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.City_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.Category)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Stock)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Province)
                .HasForeignKey(e => e.Province_Code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.City_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }
    }
}
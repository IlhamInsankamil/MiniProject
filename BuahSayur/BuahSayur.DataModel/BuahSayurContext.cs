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
        public virtual DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public virtual DbSet<DeliveryOrderDetail> DeliveryOrderDetails { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<PurchasingOrder> PurchasingOrders { get; set; }
        public virtual DbSet<PurchasingOrderDetail> PurchasingOrderDetails { get; set; }
        public virtual DbSet<ReturnOrder> ReturnOrders { get; set; }
        public virtual DbSet<ReturnOrderDetail> ReturnOrderDetails { get; set; }
        public virtual DbSet<ShipmentOrder> ShipmentOrders { get; set; }
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
                .Property(e => e.Username)
                .IsUnicode(false);

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

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.DeliveryOrders)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_Username)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryOrder>()
                .Property(e => e.Customer_Username)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryOrder>()
                .Property(e => e.Reference)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryOrder>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryOrder>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryOrder>()
                .HasMany(e => e.DeliveryOrderDetails)
                .WithRequired(e => e.DeliveryOrder)
                .HasForeignKey(e => e.DeliveryOrder_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryOrder>()
                .HasMany(e => e.ReturnOrders)
                .WithRequired(e => e.DeliveryOrder)
                .HasForeignKey(e => e.DeliveryOrder_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryOrder>()
                .HasMany(e => e.ShipmentOrders)
                .WithRequired(e => e.DeliveryOrder)
                .HasForeignKey(e => e.DeliveryOrder_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryOrderDetail>()
                .Property(e => e.Item_Code)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryOrderDetail>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 4);

            modelBuilder.Entity<DeliveryOrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DeliveryOrderDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DeliveryOrderDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryOrderDetail>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Price_Selling)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.Price_Purchasing)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.Category)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Stock)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.Weight)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.Size)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.DeliveryOrderDetails)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.Item_Code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.PurchasingOrderDetails)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.Item_Code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.ReturnOrderDetails)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.Item_Code)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<PurchasingOrder>()
                .Property(e => e.Supplier_Code)
                .IsUnicode(false);

            modelBuilder.Entity<PurchasingOrder>()
                .Property(e => e.Reference)
                .IsUnicode(false);

            modelBuilder.Entity<PurchasingOrder>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<PurchasingOrder>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<PurchasingOrder>()
                .HasMany(e => e.PurchasingOrderDetails)
                .WithRequired(e => e.PurchasingOrder)
                .HasForeignKey(e => e.PurchasingOrder_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchasingOrderDetail>()
                .Property(e => e.Item_Code)
                .IsUnicode(false);

            modelBuilder.Entity<PurchasingOrderDetail>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PurchasingOrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchasingOrderDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchasingOrderDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<PurchasingOrderDetail>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.Reference)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .HasMany(e => e.ReturnOrderDetails)
                .WithRequired(e => e.ReturnOrder)
                .HasForeignKey(e => e.Return_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReturnOrderDetail>()
                .Property(e => e.Item_Code)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrderDetail>()
                .Property(e => e.ReturnAmount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ReturnOrderDetail>()
                .Property(e => e.Replacement)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ReturnOrderDetail>()
                .Property(e => e.Shortage)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ReturnOrderDetail>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrderDetail>()
                .Property(e => e.CeatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrderDetail>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ShipmentOrder>()
                .Property(e => e.Vehicle)
                .IsUnicode(false);

            modelBuilder.Entity<ShipmentOrder>()
                .Property(e => e.PersonInCharge)
                .IsUnicode(false);

            modelBuilder.Entity<ShipmentOrder>()
                .Property(e => e.Fee)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ShipmentOrder>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ShipmentOrder>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

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

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.PurchasingOrders)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.Supplier_Code)
                .WillCascadeOnDelete(false);
        }
    }
}

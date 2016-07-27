namespace ApexAssignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AWModel : DbContext
    {
        public AWModel()
            : base("name=AWModel")
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.PersonType)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.PersonID);

            modelBuilder.Entity<Product>()
                .Property(e => e.StandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.SizeUnitMeasureCode)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.WeightUnitMeasureCode)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Weight)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductLine)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Class)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Style)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.AccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.SalesOrderHeaders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.UnitPriceDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.LineTotal)
                .HasPrecision(38, 6);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.CreditCardApprovalCode)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.TaxAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.TotalDue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Store)
                .HasForeignKey(e => e.StoreID);
        }
    }
}

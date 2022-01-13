using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace POSale.Models
{
    public partial class POSaleContext : DbContext
    {
        public POSaleContext()
        {
        }

        public POSaleContext(DbContextOptions<POSaleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleLine> SaleLines { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-71PMDI8\\SQLEXPRESS;Database=POSale;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CategoryLevel)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CategorySerial)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyBy).HasMaxLength(30);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CustomerDateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CustomerFeedback).HasMaxLength(30);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CustomerPassword)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CustomerUsername)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyBy).HasMaxLength(30);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ProductSerial)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.VendorId).ValueGeneratedOnAdd();

                entity.Property(e => e.VendorAddress)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.VendorDateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.VendorEmail)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.VendorFeedback).HasMaxLength(30);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.VendorPassword)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.VendorUsername)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

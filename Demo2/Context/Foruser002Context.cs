using System;
using System.Collections.Generic;
using Demo2.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Context;

public partial class Foruser002Context : DbContext
{
    public Foruser002Context()
    {
    }

    public Foruser002Context(DbContextOptions<Foruser002Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Categori> Categoris { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategori> ProductCategoris { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=lorksipt.ru;Database=foruser002;Username=user002;password=12232");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.DrandId).HasName("brands_pkey");

            entity.ToTable("brands");

            entity.HasIndex(e => e.BarandName, "brands_barand_name_key").IsUnique();

            entity.Property(e => e.DrandId).HasColumnName("drand_id");
            entity.Property(e => e.BarandName)
                .HasMaxLength(255)
                .HasColumnName("barand_name");
        });

        modelBuilder.Entity<Categori>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("categoris_pkey");

            entity.ToTable("categoris");

            entity.HasIndex(e => e.CategoryName, "categoris_category_name_key").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.Discrip).HasColumnName("discrip");
            entity.Property(e => e.DrandId).HasColumnName("drand_id");
            entity.Property(e => e.MidRating)
                .HasPrecision(3, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("mid_rating");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("products_user_id_fkey");
        });

        modelBuilder.Entity<ProductCategori>(entity =>
        {
            entity.HasKey(e => e.ProductCategoriId).HasName("product_categoris_pkey");

            entity.ToTable("product_categoris");

            entity.Property(e => e.ProductCategoriId).HasColumnName("product_categori_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductCategoris)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("product_categoris_category_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCategoris)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("product_categoris_product_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RegistDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("regist_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

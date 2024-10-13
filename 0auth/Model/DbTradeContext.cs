using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _0auth.Model;

public partial class DbTradeContext : DbContext
{
    public DbTradeContext()
    {
    }

    public DbTradeContext(DbContextOptions<DbTradeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=db_trade", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.IdManufacturer).HasName("PRIMARY");

            entity.ToTable("manufacturers");

            entity.Property(e => e.IdManufacturer)
                .ValueGeneratedNever()
                .HasColumnName("id_manufacturer");
            entity.Property(e => e.NameManufacturer)
                .HasColumnType("text")
                .HasColumnName("name_manufacturer");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.IdPoint, "pointID_idx");

            entity.HasIndex(e => e.IdOrderStatus, "status_idx");

            entity.HasIndex(e => e.IdUser, "userID_idx");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.CodeOrder).HasColumnName("code_order");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("delivery_date");
            entity.Property(e => e.DispatchDate)
                .HasColumnType("datetime")
                .HasColumnName("dispatch_date");
            entity.Property(e => e.IdOrderStatus).HasColumnName("id_order_status");
            entity.Property(e => e.IdPoint).HasColumnName("id_point");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdOrderStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdOrderStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("status");

            entity.HasOne(d => d.IdPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdPoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pointID");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("userID");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.IdOrderProduct).HasName("PRIMARY");

            entity.ToTable("order_products");

            entity.HasIndex(e => e.IdOrder, "orderID_idx");

            entity.HasIndex(e => e.ProductArticleNumber, "productArticleNumber_idx");

            entity.Property(e => e.IdOrderProduct)
                .HasMaxLength(45)
                .HasColumnName("id_order_product");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.ProductArticleNumber)
                .HasMaxLength(100)
                .HasColumnName("product_article_number")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderID");

            entity.HasOne(d => d.ProductArticleNumberNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductArticleNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productArticleNumber");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.IdOrderStatus).HasName("PRIMARY");

            entity.ToTable("order_statuses");

            entity.Property(e => e.IdOrderStatus)
                .ValueGeneratedNever()
                .HasColumnName("id_order_status");
            entity.Property(e => e.NameOrderStatus)
                .HasColumnType("text")
                .HasColumnName("name_order_status");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => e.IdPoint).HasName("PRIMARY");

            entity.ToTable("points");

            entity.Property(e => e.IdPoint)
                .ValueGeneratedNever()
                .HasColumnName("id_point");
            entity.Property(e => e.AddressPoint)
                .HasColumnType("text")
                .HasColumnName("address_point");
            entity.Property(e => e.PostCode).HasColumnName("post_code");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductArticleNumber).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.IdManufacturer, "manufac_idx");

            entity.HasIndex(e => e.IdProductType, "productType_idx");

            entity.HasIndex(e => e.IdSupplier, "sup_idx");

            entity.Property(e => e.ProductArticleNumber)
                .HasMaxLength(100)
                .HasColumnName("product_article_number")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CostProduct)
                .HasPrecision(19, 4)
                .HasColumnName("cost_product");
            entity.Property(e => e.CurrentDiscount).HasColumnName("current_discount");
            entity.Property(e => e.DescriptionProduct)
                .HasColumnType("text")
                .HasColumnName("description_product");
            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.IdProductType).HasColumnName("id_product_type");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.MaxDiscount).HasColumnName("max_discount");
            entity.Property(e => e.MeasureProduct)
                .HasMaxLength(45)
                .HasColumnName("measure_product");
            entity.Property(e => e.NameProduct)
                .HasColumnType("text")
                .HasColumnName("name_product");
            entity.Property(e => e.PhotoProduct)
                .HasColumnType("text")
                .HasColumnName("photo_product");
            entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");
            entity.Property(e => e.StatusProduct)
                .HasColumnType("text")
                .HasColumnName("status_product");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdManufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("manufac");

            entity.HasOne(d => d.IdProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productType");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sup");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.IdProductType).HasName("PRIMARY");

            entity.ToTable("product_types");

            entity.Property(e => e.IdProductType)
                .ValueGeneratedNever()
                .HasColumnName("id_product_type");
            entity.Property(e => e.NameProductType)
                .HasColumnType("text")
                .HasColumnName("name_product_type");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(100)
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.Property(e => e.IdSupplier)
                .ValueGeneratedNever()
                .HasColumnName("id_supplier");
            entity.Property(e => e.NameSupplier)
                .HasColumnType("text")
                .HasColumnName("name_supplier");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdRole, "role_idx");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.LoginUser)
                .HasColumnType("text")
                .HasColumnName("login_user");
            entity.Property(e => e.NameUser)
                .HasMaxLength(100)
                .HasColumnName("name_user");
            entity.Property(e => e.PasswordUser)
                .HasColumnType("text")
                .HasColumnName("password_user");
            entity.Property(e => e.PatronymicUser)
                .HasMaxLength(100)
                .HasColumnName("patronymic_user");
            entity.Property(e => e.SurnameUser)
                .HasMaxLength(100)
                .HasColumnName("surname_user");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BreadFactoryIS.DataBase;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduction> OrderProductions { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Production> Productions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=SQLStudv2;Database=22ip16;User Id=22ip16;Password=22ip16");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Customer_pkey");

            entity.ToTable("Customer", "Up07");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.IdUser).HasColumnName("ID_user");
            entity.Property(e => e.Inn)
                .HasMaxLength(20)
                .HasColumnName("INN");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(12);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Customer_ID_user_fkey");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Manufacturer_pkey");

            entity.ToTable("Manufacturer", "Up07");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.IdUser).HasColumnName("ID_user");
            entity.Property(e => e.Inn)
                .HasMaxLength(20)
                .HasColumnName("INN");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(12);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Manufacturers)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Manufacturer_ID_user_fkey");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Material_pkey");

            entity.ToTable("Material", "Up07");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasColumnType("character varying");
            entity.Property(e => e.IdManufacturer).HasColumnName("ID_manufacturer");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(100);
            entity.Property(e => e.Unit).HasMaxLength(20);
            entity.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasColumnName("Unit_price");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.IdManufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Material_ID_manufacturer_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order_pkey");

            entity.ToTable("Order", "Up07");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.IdCustomer).HasColumnName("ID_customer");
            entity.Property(e => e.IdStatus).HasColumnName("ID_status");
            entity.Property(e => e.OrderDate).HasColumnName("Order_date");
            entity.Property(e => e.OrderSum)
                .HasColumnType("money")
                .HasColumnName("Order_sum");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_ID_customer_fkey");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_ID_status_fkey");
        });

        modelBuilder.Entity<OrderProduction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order-production_pkey");

            entity.ToTable("Order-production", "Up07");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, 0L, null, null, null)
                .HasColumnName("ID");
            entity.Property(e => e.IdOrder).HasColumnName("ID_order");
            entity.Property(e => e.IdProduction).HasColumnName("ID_production");
            entity.Property(e => e.ProductionQuantity).HasColumnName("Production_quantity");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderProductions)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order-production_ID_order_fkey");

            entity.HasOne(d => d.IdProductionNavigation).WithMany(p => p.OrderProductions)
                .HasForeignKey(d => d.IdProduction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order-production_ID_production_fkey");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("OrderStatus_pkey");

            entity.ToTable("OrderStatus", "Up07");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Production_pkey");

            entity.ToTable("Production", "Up07");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasColumnType("character varying");
            entity.Property(e => e.IdManufacturer).HasColumnName("ID_Manufacturer");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(100);
            entity.Property(e => e.Unit).HasMaxLength(20);
            entity.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasColumnName("Unit_price");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Productions)
                .HasForeignKey(d => d.IdManufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Production_ID_manufacturer_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("Role", "Up07");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Specification_pkey");

            entity.ToTable("Specification", "Up07");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.IdMaterial).HasColumnName("ID_material");
            entity.Property(e => e.IdProduction).HasColumnName("ID_production");
            entity.Property(e => e.MaterialQuanitity).HasColumnName("Material_quanitity");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.Specifications)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Specification_ID_material_fkey");

            entity.HasOne(d => d.IdProductionNavigation).WithMany(p => p.Specifications)
                .HasForeignKey(d => d.IdProduction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Specification_ID_production_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User", "Up07");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.IdRole).HasColumnName("ID_role");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Middlename).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_ID_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

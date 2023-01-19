using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmjleFood_Project.Data.Entity;

namespace SmjleFood_Project.Data.Context
{
    public partial class SmjleFoodDBContext : DbContext
    {
        public SmjleFoodDBContext()
        {
        }

        public SmjleFoodDBContext(DbContextOptions<SmjleFoodDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<BrandInArea> BrandInAreas { get; set; } = null!;
        public virtual DbSet<Destination> Destinations { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OtherAmount> OtherAmounts { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductCollection> ProductCollections { get; set; } = null!;
        public virtual DbSet<ProductCollectionInMenu> ProductCollectionInMenus { get; set; } = null!;
        public virtual DbSet<ProductCollectionItem> ProductCollectionItems { get; set; } = null!;
        public virtual DbSet<ProductCombination> ProductCombinations { get; set; } = null!;
        public virtual DbSet<ProductInMenu> ProductInMenus { get; set; } = null!;
        public virtual DbSet<Recipient> Recipients { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<TimeSlot> TimeSlots { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=robot;database=SmjleFoodDB", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountCode).HasMaxLength(50);

                entity.Property(e => e.AccountName).HasMaxLength(100);

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ProductCode).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.StoreCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Brand_Store");
            });

            modelBuilder.Entity<BrandInArea>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.AreaId })
                    .HasName("PK__BrandInA__AC897305B9457FC9");

                entity.ToTable("BrandInArea");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.BrandInAreaAreas)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrandInArea_Brand1");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.BrandInAreaStores)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrandInArea_Brand");
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.ToTable("Destination");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Destinations)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Destination_Brand");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.MenuName).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Menu_Brand");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.ArriveTime).HasMaxLength(200);

                entity.Property(e => e.DeliveryPhone).HasMaxLength(12);

                entity.Property(e => e.OrderCode).HasMaxLength(50);

                entity.Property(e => e.TimeSlot).HasMaxLength(20);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Order_Destination");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_OrderDetail_OrderDetail");

                entity.HasOne(d => d.ProductInMenu)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductInMenuId)
                    .HasConstraintName("FK_OrderDetail_ProductInMenu");

                entity.HasOne(d => d.SupplierStore)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.SupplierStoreId)
                    .HasConstraintName("FK_OrderDetail_Brand");
            });

            modelBuilder.Entity<OtherAmount>(entity =>
            {
                entity.ToTable("OtherAmount");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Unit).HasMaxLength(10);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OtherAmounts)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OtherAmount_Order");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransactionId).HasMaxLength(30);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.ToRent)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ToRentId)
                    .HasConstraintName("FK_Payment_Order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Base).HasMaxLength(100);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.Size).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_Product_ProductCategory");

                entity.HasOne(d => d.GeneralProduct)
                    .WithMany(p => p.InverseGeneralProduct)
                    .HasForeignKey(d => d.GeneralProductId)
                    .HasConstraintName("FK_Product_Product");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Product_Store");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.PrpductCategoryCode).HasMaxLength(30);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductCollection>(entity =>
            {
                entity.ToTable("ProductCollection");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductCollections)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_ProductCollection_Store");
            });

            modelBuilder.Entity<ProductCollectionInMenu>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ProductCollectionId, e.MenuId })
                    .HasName("PK__ProductC__71A448ECC4BAE5A2");

                entity.ToTable("ProductCollectionInMenu");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.ProductCollectionInMenus)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCollectionInMenu_Menu");

                entity.HasOne(d => d.ProductCollection)
                    .WithMany(p => p.ProductCollectionInMenus)
                    .HasForeignKey(d => d.ProductCollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCollectionInMenu_ProductCollection");
            });

            modelBuilder.Entity<ProductCollectionItem>(entity =>
            {
                entity.ToTable("ProductCollectionItem");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.ProductCollection)
                    .WithMany(p => p.ProductCollectionItems)
                    .HasForeignKey(d => d.ProductCollectionId)
                    .HasConstraintName("FK_ProductCollectionItem_ProductCollection");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCollectionItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductCollectionItem_Product");
            });

            modelBuilder.Entity<ProductCombination>(entity =>
            {
                entity.HasKey(e => new { e.BaseProductId, e.ProductId, e.GroupId })
                    .HasName("PK_ComboDetail");

                entity.ToTable("ProductCombination");

                entity.HasIndex(e => e.ProductId, "IX_ProductCombination_ProductId");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DefaultMinMax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.BaseProduct)
                    .WithMany(p => p.ProductCombinationBaseProducts)
                    .HasForeignKey(d => d.BaseProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCombination_Product");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCombinationProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCombination_Product1");
            });

            modelBuilder.Entity<ProductInMenu>(entity =>
            {
                entity.ToTable("ProductInMenu");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.ProductInMenus)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_ProductInMenu_Menu");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInMenus)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductInMenu_Product");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductInMenus)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_ProductInMenu_Store");
            });

            modelBuilder.Entity<Recipient>(entity =>
            {
                entity.ToTable("Recipient");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Recipients)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Recipient_Order");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Recipients)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Recipient_User");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.ContactPerson).HasMaxLength(100);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.PhoneNumber).HasMaxLength(12);

                entity.Property(e => e.StoreName).HasMaxLength(50);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.ToTable("TimeSlot");

                entity.Property(e => e.ArriveTime).HasMaxLength(50);

                entity.Property(e => e.CheckoutTime).HasMaxLength(50);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.TimeSlots)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_TimeSlot_menu");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.TransactionCode).HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Transaction_Account");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Pass).HasMaxLength(256);

                entity.Property(e => e.RoleType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Staff_Brand");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.staff)
                    .HasForeignKey<staff>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

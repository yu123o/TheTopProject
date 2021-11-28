using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TheTopProject.Models
{
    public partial class TheTopDatabaseContext : DbContext
    {
        public TheTopDatabaseContext()
        {
        }

        public TheTopDatabaseContext(DbContextOptions<TheTopDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Deduction> Deduction { get; set; }
        public virtual DbSet<Design> Design { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAttendence> EmployeeAttendence { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<WebSiteInfo> WebSiteInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2KCLJUL\\SQLEXPRESS;Database=TheTopDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Admin__A9D1053467E6A0C5")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__CustomerId__18EBB532");

                entity.HasOne(d => d.Design)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.DesignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__DesignId__17F790F9");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.DateofAdd).HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("PK__CreditCa__FD291E40AAF6BB8E");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("numeric(38, 0)");

                entity.Property(e => e.Balance).HasColumnName("balance");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Customer__A9D105348274F8D2")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationTime).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Deduction>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Deduction)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deduction__Emplo__151B244E");
            });

            modelBuilder.Entity<Design>(entity =>
            {
                entity.Property(e => e.AddDate).HasColumnType("date");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categroy)
                    .WithMany(p => p.Design)
                    .HasForeignKey(d => d.CategroyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Design__Categroy__34C8D9D1");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Design)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Design__Customer__35BCFE0A");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Employee__A9D10534D11EC192")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartWorkTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeAttendence>(entity =>
            {
                entity.Property(e => e.LoginTime).HasColumnType("date");

                entity.Property(e => e.LogoutTime).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAttendence)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__Emplo__44CA3770");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.EndTime).HasColumnType("date");

                entity.Property(e => e.StartTime).HasColumnType("date");

                entity.HasOne(d => d.Design)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.DesignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Offer__DesignId__403A8C7D");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReviewText)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__Customer__3D5E1FD2");

                entity.HasOne(d => d.Design)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.DesignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__DesignId__3C69FB99");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__CustomerI__398D8EEE");

                entity.HasOne(d => d.Design)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.DesignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__DesignId__38996AB5");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.InsertTime).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaskContent)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tasks__EmployeeI__3C34F16F");
            });

            modelBuilder.Entity<WebSiteInfo>(entity =>
            {
                entity.Property(e => e.Header)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SmallDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheTopProject.Models;

namespace TheTopProject.Migrations
{
    [DbContext(typeof(TheTopDatabaseContext))]
    [Migration("20211003175705_update design")]
    partial class updatedesign
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheTopProject.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnName("FName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnName("LName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__Admin__A9D1053467E6A0C5");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("TheTopProject.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateofAdd")
                        .HasColumnType("datetime");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TheTopProject.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Approve")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Message")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("TheTopProject.Models.CreditCard", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnName("number")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnName("balance")
                        .HasColumnType("float");

                    b.HasKey("Number")
                        .HasName("PK__CreditCa__FD291E40AAF6BB8E");

                    b.ToTable("CreditCard");
                });

            modelBuilder.Entity("TheTopProject.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnName("FName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnName("LName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Subject")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__Customer__A9D105348274F8D2");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TheTopProject.Models.Design", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategroyId")
                        .HasColumnType("int");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategroyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Design");
                });

            modelBuilder.Entity("TheTopProject.Models.Detuction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Detuction");
                });

            modelBuilder.Entity("TheTopProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnName("FName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("JobTitle")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnName("LName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartWorkTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__Employee__A9D10534D11EC192");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("TheTopProject.Models.EmployeeAttendence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("LoginTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("LogoutTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeAttendence");
                });

            modelBuilder.Entity("TheTopProject.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("DesignId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("date");

                    b.Property<double>("NewCost")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("DesignId");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("TheTopProject.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CompanyRatio")
                        .HasColumnType("float");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime");

                    b.Property<int>("DesignId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DesignId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("TheTopProject.Models.Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CompanyRatio")
                        .HasColumnType("float");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime");

                    b.Property<int>("DesignId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DesignId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("TheTopProject.Models.WebSiteInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("SmallDescription")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("WebSiteInfo");
                });

            modelBuilder.Entity("TheTopProject.Models.Design", b =>
                {
                    b.HasOne("TheTopProject.Models.Category", "Categroy")
                        .WithMany("Design")
                        .HasForeignKey("CategroyId")
                        .HasConstraintName("FK__Design__Categroy__34C8D9D1")
                        .IsRequired();

                    b.HasOne("TheTopProject.Models.Customer", "Customer")
                        .WithMany("Design")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Design__Customer__35BCFE0A")
                        .IsRequired();
                });

            modelBuilder.Entity("TheTopProject.Models.Detuction", b =>
                {
                    b.HasOne("TheTopProject.Models.Customer", "Customer")
                        .WithMany("Detuction")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Detuction__Custo__4316F928")
                        .IsRequired();
                });

            modelBuilder.Entity("TheTopProject.Models.EmployeeAttendence", b =>
                {
                    b.HasOne("TheTopProject.Models.Employee", "Employee")
                        .WithMany("EmployeeAttendence")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__EmployeeA__Emplo__2F10007B")
                        .IsRequired();
                });

            modelBuilder.Entity("TheTopProject.Models.Offer", b =>
                {
                    b.HasOne("TheTopProject.Models.Design", "Design")
                        .WithMany("Offer")
                        .HasForeignKey("DesignId")
                        .HasConstraintName("FK__Offer__DesignId__403A8C7D")
                        .IsRequired();
                });

            modelBuilder.Entity("TheTopProject.Models.Review", b =>
                {
                    b.HasOne("TheTopProject.Models.Customer", "Customer")
                        .WithMany("Review")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Review__Customer__3D5E1FD2")
                        .IsRequired();

                    b.HasOne("TheTopProject.Models.Design", "Design")
                        .WithMany("Review")
                        .HasForeignKey("DesignId")
                        .HasConstraintName("FK__Review__DesignId__3C69FB99")
                        .IsRequired();
                });

            modelBuilder.Entity("TheTopProject.Models.Sales", b =>
                {
                    b.HasOne("TheTopProject.Models.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Sales__CustomerI__398D8EEE")
                        .IsRequired();

                    b.HasOne("TheTopProject.Models.Design", "Design")
                        .WithMany("Sales")
                        .HasForeignKey("DesignId")
                        .HasConstraintName("FK__Sales__DesignId__38996AB5")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
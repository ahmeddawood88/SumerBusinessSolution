﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SumerBusinessSolution.Data;

namespace SumerBusinessSolution.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200319075016_creatingPriceTypeTable")]
    partial class creatingPriceTypeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.BillHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDataTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustId")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PaidAmt")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmt")
                        .HasColumnType("float");

                    b.Property<double>("TotalNetAmt")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CustId");

                    b.ToTable("BillHeader");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.BillItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProdId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<double>("TotalAmt")
                        .HasColumnType("float");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HeaderId");

                    b.HasIndex("ProdId");

                    b.ToTable("BillItems");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.BillPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillHeaderId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedById")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PaidAmt")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BillHeaderId");

                    b.HasIndex("CustId");

                    b.ToTable("BillPayment");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.CustAcc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustId")
                        .HasColumnType("int");

                    b.Property<double>("Debt")
                        .HasColumnType("float");

                    b.Property<double>("Paid")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustId");

                    b.ToTable("CustAcc");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.IncomingGood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProdId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<string>("UOM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WhId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ProdId");

                    b.HasIndex("WhId");

                    b.ToTable("IncomingGood");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.InvStockQty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<string>("UOM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WhId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdId");

                    b.HasIndex("WhId");

                    b.ToTable("InvStockQty");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.InvTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProdId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<string>("TransType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WhId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ProdId");

                    b.HasIndex("WhId");

                    b.ToTable("InvTransaction");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.InvTransfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProdId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<string>("UOM")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeaderId");

                    b.HasIndex("ProdId");

                    b.ToTable("InvTransfer");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.InvTransferHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApprovedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FromWhId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ToWhId")
                        .HasColumnType("int");

                    b.Property<string>("TransferStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("CreatedById");

                    b.HasIndex("FromWhId");

                    b.HasIndex("ToWhId");

                    b.ToTable("InvTransferHeader");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.PricingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PricingType");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.ProdImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImgFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdId");

                    b.ToTable("ProdImg");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.ProdInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RetailPrice")
                        .HasColumnType("float");

                    b.Property<double>("WholePrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("ProdInfo");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.TempProdImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImgFile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TempProdImg");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("WhCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("TypeId");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.WhType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WhType");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.BillHeader", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumerBusinessSolution.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustId");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.BillItems", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.BillHeader", "BillHeader")
                        .WithMany()
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumerBusinessSolution.Models.ProdInfo", "ProdInfo")
                        .WithMany()
                        .HasForeignKey("ProdId");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.BillPayment", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.BillHeader", "BillHeader")
                        .WithMany()
                        .HasForeignKey("BillHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumerBusinessSolution.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustId");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.CustAcc", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.Customer", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.IncomingGood", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumerBusinessSolution.Models.ProdInfo", "ProdInfo")
                        .WithMany()
                        .HasForeignKey("ProdId");

                    b.HasOne("SumerBusinessSolution.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WhId");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.InvStockQty", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.ProdInfo", "ProdInfo")
                        .WithMany()
                        .HasForeignKey("ProdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumerBusinessSolution.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WhId");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.InvTransaction", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumerBusinessSolution.Models.ProdInfo", "ProdInfo")
                        .WithMany()
                        .HasForeignKey("ProdId");

                    b.HasOne("SumerBusinessSolution.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WhId");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.InvTransfer", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.InvTransferHeader", "InvTransferHeader")
                        .WithMany()
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumerBusinessSolution.Models.ProdInfo", "ProdInfo")
                        .WithMany()
                        .HasForeignKey("ProdId");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.InvTransferHeader", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.ApplicationUser", "ApprovedApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApprovedById");

                    b.HasOne("SumerBusinessSolution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumerBusinessSolution.Models.Warehouse", "ToWarehouse")
                        .WithMany()
                        .HasForeignKey("FromWhId");

                    b.HasOne("SumerBusinessSolution.Models.Warehouse", "FromWarehouse")
                        .WithMany()
                        .HasForeignKey("ToWhId");
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.ProdImg", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.ProdInfo", "ProdInfo")
                        .WithMany()
                        .HasForeignKey("ProdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.ProdInfo", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SumerBusinessSolution.Models.Warehouse", b =>
                {
                    b.HasOne("SumerBusinessSolution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumerBusinessSolution.Models.WhType", "WhType")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

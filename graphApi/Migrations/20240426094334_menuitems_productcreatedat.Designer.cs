﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using graphApi.DataAccess.Entity;

#nullable disable

namespace graphApi.Migrations
{
    [DbContext(typeof(SampleAppDbContext))]
    [Migration("20240426094334_menuitems_productcreatedat")]
    partial class menuitems_productcreatedat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("graphApi.DataAccess.Entity.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeoId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SeoId");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AltText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.MenuItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Money", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Money");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BodySummary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeoId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SeoId");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.PriceRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("MaxVariantPrice")
                        .HasColumnType("float");

                    b.Property<double>("MinVariantPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("PriceRange");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AvailableForSale")
                        .HasColumnType("bit");

                    b.Property<int?>("CollectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionHtml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FeaturedImageId")
                        .HasColumnType("int");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceId")
                        .HasColumnType("int");

                    b.Property<int>("PriceRangeId")
                        .HasColumnType("int");

                    b.Property<int?>("SeoId")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("FeaturedImageId");

                    b.HasIndex("PriceId");

                    b.HasIndex("PriceRangeId");

                    b.HasIndex("SeoId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.ProductOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Values")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOption");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.ProductVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AvailableForSale")
                        .HasColumnType("bit");

                    b.Property<int>("PriceId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PriceId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVariant");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.SelectedOptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductVariantId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductVariantId");

                    b.ToTable("SelectedOptions");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Seo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seo");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Collection", b =>
                {
                    b.HasOne("graphApi.DataAccess.Entity.Seo", "Seo")
                        .WithMany()
                        .HasForeignKey("SeoId");

                    b.Navigation("Seo");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Employee", b =>
                {
                    b.HasOne("graphApi.DataAccess.Entity.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Image", b =>
                {
                    b.HasOne("graphApi.DataAccess.Entity.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.MenuItems", b =>
                {
                    b.HasOne("graphApi.DataAccess.Entity.Menu", null)
                        .WithMany("Items")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Page", b =>
                {
                    b.HasOne("graphApi.DataAccess.Entity.Seo", "Seo")
                        .WithMany()
                        .HasForeignKey("SeoId");

                    b.Navigation("Seo");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Product", b =>
                {
                    b.HasOne("graphApi.DataAccess.Entity.Collection", null)
                        .WithMany("Products")
                        .HasForeignKey("CollectionId");

                    b.HasOne("graphApi.DataAccess.Entity.Image", "FeaturedImage")
                        .WithMany()
                        .HasForeignKey("FeaturedImageId");

                    b.HasOne("graphApi.DataAccess.Entity.Money", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("graphApi.DataAccess.Entity.PriceRange", "PriceRange")
                        .WithMany()
                        .HasForeignKey("PriceRangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("graphApi.DataAccess.Entity.Seo", "Seo")
                        .WithMany()
                        .HasForeignKey("SeoId");

                    b.Navigation("FeaturedImage");

                    b.Navigation("Price");

                    b.Navigation("PriceRange");

                    b.Navigation("Seo");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.ProductOption", b =>
                {
                    b.HasOne("graphApi.DataAccess.Entity.Product", null)
                        .WithMany("Options")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.ProductVariant", b =>
                {
                    b.HasOne("graphApi.DataAccess.Entity.Money", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("graphApi.DataAccess.Entity.Product", null)
                        .WithMany("Variants")
                        .HasForeignKey("ProductId");

                    b.Navigation("Price");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.SelectedOptions", b =>
                {
                    b.HasOne("graphApi.DataAccess.Entity.ProductVariant", null)
                        .WithMany("SelectedOptions")
                        .HasForeignKey("ProductVariantId");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Collection", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Menu", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Options");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("graphApi.DataAccess.Entity.ProductVariant", b =>
                {
                    b.Navigation("SelectedOptions");
                });
#pragma warning restore 612, 618
        }
    }
}

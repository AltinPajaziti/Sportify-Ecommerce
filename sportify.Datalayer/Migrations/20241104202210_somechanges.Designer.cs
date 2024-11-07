﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sportify.Datalayer;

#nullable disable

namespace sportify.Datalayer.Migrations
{
    [DbContext(typeof(SportifyContext))]
    [Migration("20241104202210_somechanges")]
    partial class somechanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("sportify.core.cs.Basket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Insertedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userid")
                        .IsUnique();

                    b.ToTable("basket");
                });

            modelBuilder.Entity("sportify.core.cs.BasketProduct", b =>
                {
                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<int>("BasketProductID")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPurchased")
                        .HasColumnType("bit");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("BasketId", "Productid");

                    b.HasIndex("Productid");

                    b.ToTable("BasketProduct");
                });

            modelBuilder.Entity("sportify.core.cs.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Insertedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("sportify.core.cs.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insertedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("sportify.core.cs.FavoriteProducts", b =>
                {
                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.Property<string>("Insertedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("Userid", "productid");

                    b.HasIndex("productid");

                    b.ToTable("favoriteProducts");
                });

            modelBuilder.Entity("sportify.core.cs.Products", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Insertedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stockid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("sportify.core.cs.Roles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("sportify.core.cs.Stock", b =>
                {
                    b.Property<int>("Stockid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Stockid"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Stockid");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("stock");
                });

            modelBuilder.Entity("sportify.core.cs.Users", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insertedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Roleid")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Roleid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("sportify.core.cs.Basket", b =>
                {
                    b.HasOne("sportify.core.cs.Users", "users")
                        .WithOne("Basket")
                        .HasForeignKey("sportify.core.cs.Basket", "userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("sportify.core.cs.BasketProduct", b =>
                {
                    b.HasOne("sportify.core.cs.Basket", "basket")
                        .WithMany("BasketProducts")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sportify.core.cs.Products", "products")
                        .WithMany("BasketProducts")
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("basket");

                    b.Navigation("products");
                });

            modelBuilder.Entity("sportify.core.cs.FavoriteProducts", b =>
                {
                    b.HasOne("sportify.core.cs.Users", "Userat")
                        .WithMany("FavoriteProducts")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sportify.core.cs.Products", "Produktet")
                        .WithMany("FavoriteProducts")
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produktet");

                    b.Navigation("Userat");
                });

            modelBuilder.Entity("sportify.core.cs.Stock", b =>
                {
                    b.HasOne("sportify.core.cs.Products", "Product")
                        .WithOne("stock")
                        .HasForeignKey("sportify.core.cs.Stock", "ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("sportify.core.cs.Users", b =>
                {
                    b.HasOne("sportify.core.cs.Roles", "Roli")
                        .WithMany("User")
                        .HasForeignKey("Roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roli");
                });

            modelBuilder.Entity("sportify.core.cs.Basket", b =>
                {
                    b.Navigation("BasketProducts");
                });

            modelBuilder.Entity("sportify.core.cs.Products", b =>
                {
                    b.Navigation("BasketProducts");

                    b.Navigation("FavoriteProducts");

                    b.Navigation("stock")
                        .IsRequired();
                });

            modelBuilder.Entity("sportify.core.cs.Roles", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("sportify.core.cs.Users", b =>
                {
                    b.Navigation("Basket")
                        .IsRequired();

                    b.Navigation("FavoriteProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
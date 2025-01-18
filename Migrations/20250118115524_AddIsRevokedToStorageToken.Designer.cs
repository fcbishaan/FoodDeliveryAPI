﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vashishth_Backened._24.Data;

#nullable disable

namespace Vashishth_Backened._24.Migrations
{
    [DbContext(typeof(FoodDeliveryContext))]
    [Migration("20250118115524_AddIsRevokedToStorageToken")]
    partial class AddIsRevokedToStorageToken
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("DishesId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrderId")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Vashishth_Backened._24.Models.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d39a9739-eb70-4d76-b055-b6b27f20ef0e"),
                            Category = "Pizza",
                            Description = "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы",
                            Image = "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.",
                            Name = "4 сыра",
                            Price = 360.0,
                            Rating = 4.0,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = new Guid("919fec4d-d483-4c93-a5cd-69b39a157405"),
                            Category = "Pizza",
                            Description = "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ",
                            Image = "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.",
                            Name = "Party BBQ",
                            Price = 480.0,
                            Rating = 0.0,
                            Vegetarian = false
                        },
                        new
                        {
                            Id = new Guid("bd88aa3b-0c90-4d8f-9a70-67e424b03420"),
                            Category = "Wok",
                            Description = "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.",
                            Image = "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg",
                            Name = "Wok а-ля Диаблo",
                            Price = 330.0,
                            Rating = 5.0,
                            Vegetarian = false
                        },
                        new
                        {
                            Id = new Guid("080eb6db-ba70-4a0d-a1d8-aa256e492c98"),
                            Category = "Wok",
                            Description = "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.",
                            Image = "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg",
                            Name = "Wok болоньезе",
                            Price = 290.0,
                            Rating = 0.0,
                            Vegetarian = false
                        },
                        new
                        {
                            Id = new Guid("c9f53d7a-4928-47c4-9443-a518ad6f7718"),
                            Category = "Wok",
                            Description = "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.",
                            Image = "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg",
                            Name = "Wok том ям с курицей",
                            Price = 280.0,
                            Rating = 0.0,
                            Vegetarian = false
                        });
                });

            modelBuilder.Entity("Vashishth_Backened._24.Models.Orders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("OrderTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("deliveryTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("price")
                        .HasColumnType("integer");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Vashishth_Backened._24.Models.StorageToken", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("boolean");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("StorageTokens");
                });

            modelBuilder.Entity("Vashishth_Backened._24.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

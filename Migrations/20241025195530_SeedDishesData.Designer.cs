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
    [Migration("20241025195530_SeedDishesData")]
    partial class SeedDishesData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                            Id = new Guid("dcb82183-1062-4713-86f7-eb98bda6007c"),
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
                            Id = new Guid("a30110e4-0a03-4e27-9f41-f08bb39bf77d"),
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
                            Id = new Guid("617c17dc-e472-41ef-8f71-81e5ca1d8f5a"),
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
                            Id = new Guid("ae79b024-9236-4226-9c6a-5b5fea0cad5c"),
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
                            Id = new Guid("a1d42ef3-8937-47df-be05-a2e120c075d5"),
                            Category = "Wok",
                            Description = "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.",
                            Image = "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg",
                            Name = "Wok том ям с курицей",
                            Price = 280.0,
                            Rating = 0.0,
                            Vegetarian = false
                        });
                });

            modelBuilder.Entity("Vashishth_Backened._24.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

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
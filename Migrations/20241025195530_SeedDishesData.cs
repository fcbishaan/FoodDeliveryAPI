using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vashishth_Backened._24.Migrations
{
    /// <inheritdoc />
    public partial class SeedDishesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vegetarian",
                table: "Dishes",
                newName: "Vegetarian");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Dishes",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Dishes",
                newName: "Category");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Rating", "Vegetarian" },
                values: new object[,]
                {
                    { new Guid("617c17dc-e472-41ef-8f71-81e5ca1d8f5a"), "Wok", "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.", "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok а-ля Диаблo", 330.0, 5.0, false },
                    { new Guid("a1d42ef3-8937-47df-be05-a2e120c075d5"), "Wok", "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.", "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с курицей", 280.0, 0.0, false },
                    { new Guid("a30110e4-0a03-4e27-9f41-f08bb39bf77d"), "Pizza", "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ", "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.", "Party BBQ", 480.0, 0.0, false },
                    { new Guid("ae79b024-9236-4226-9c6a-5b5fea0cad5c"), "Wok", "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.", "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok болоньезе", 290.0, 0.0, false },
                    { new Guid("dcb82183-1062-4713-86f7-eb98bda6007c"), "Pizza", "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы", "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.", "4 сыра", 360.0, 4.0, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("617c17dc-e472-41ef-8f71-81e5ca1d8f5a"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("a1d42ef3-8937-47df-be05-a2e120c075d5"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("a30110e4-0a03-4e27-9f41-f08bb39bf77d"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("ae79b024-9236-4226-9c6a-5b5fea0cad5c"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("dcb82183-1062-4713-86f7-eb98bda6007c"));

            migrationBuilder.RenameColumn(
                name: "Vegetarian",
                table: "Dishes",
                newName: "vegetarian");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Dishes",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Dishes",
                newName: "category");
        }
    }
}

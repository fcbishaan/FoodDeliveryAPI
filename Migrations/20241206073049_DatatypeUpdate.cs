using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vashishth_Backened._24.Migrations
{
    /// <inheritdoc />
    public partial class DatatypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("6795e7ba-6a93-42da-9b26-6c869f4446ee"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("afdbcf6e-2e79-45be-96e2-12e4f15758ff"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("c04e981d-cbee-4de6-a4a7-ffed73140a25"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("d98b9acf-4cac-4988-94c9-ad2ebe45c649"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("dcb21c90-274c-4411-a5e0-079c9693e166"));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Baskets",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Baskets",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DishesId",
                table: "Baskets",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Rating", "Vegetarian" },
                values: new object[,]
                {
                    { new Guid("2ba22276-0024-42f6-af4e-d30636eafb48"), "Wok", "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.", "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с курицей", 280.0, 0.0, false },
                    { new Guid("68accf26-8a4b-45dd-8771-485fa1f3b4b6"), "Wok", "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.", "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok болоньезе", 290.0, 0.0, false },
                    { new Guid("7fab379f-83dd-4539-ba78-e323e99183b7"), "Wok", "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.", "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok а-ля Диаблo", 330.0, 5.0, false },
                    { new Guid("e9c9dbe3-8bac-44cf-a373-9df504b1d5e6"), "Pizza", "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ", "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.", "Party BBQ", 480.0, 0.0, false },
                    { new Guid("ef02d7cf-7b52-4484-afc2-e9f3651e8dd3"), "Pizza", "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы", "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.", "4 сыра", 360.0, 4.0, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("2ba22276-0024-42f6-af4e-d30636eafb48"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("68accf26-8a4b-45dd-8771-485fa1f3b4b6"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("7fab379f-83dd-4539-ba78-e323e99183b7"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e9c9dbe3-8bac-44cf-a373-9df504b1d5e6"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("ef02d7cf-7b52-4484-afc2-e9f3651e8dd3"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Baskets",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "Baskets",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DishesId",
                table: "Baskets",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Rating", "Vegetarian" },
                values: new object[,]
                {
                    { new Guid("6795e7ba-6a93-42da-9b26-6c869f4446ee"), "Wok", "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.", "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok болоньезе", 290.0, 0.0, false },
                    { new Guid("afdbcf6e-2e79-45be-96e2-12e4f15758ff"), "Pizza", "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы", "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.", "4 сыра", 360.0, 4.0, true },
                    { new Guid("c04e981d-cbee-4de6-a4a7-ffed73140a25"), "Wok", "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.", "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с курицей", 280.0, 0.0, false },
                    { new Guid("d98b9acf-4cac-4988-94c9-ad2ebe45c649"), "Wok", "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.", "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok а-ля Диаблo", 330.0, 5.0, false },
                    { new Guid("dcb21c90-274c-4411-a5e0-079c9693e166"), "Pizza", "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ", "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.", "Party BBQ", 480.0, 0.0, false }
                });
        }
    }
}

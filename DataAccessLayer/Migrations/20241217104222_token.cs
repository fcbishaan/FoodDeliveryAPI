using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vashishth_Backened._24.Migrations
{
    /// <inheritdoc />
    public partial class token : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "StorageTokens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageTokens", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Rating", "Vegetarian" },
                values: new object[,]
                {
                    { new Guid("233dd476-de88-46c5-b231-f54f0f929fac"), "Pizza", "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы", "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.", "4 сыра", 360.0, 4.0, true },
                    { new Guid("47c18313-0aae-48ae-be77-2522b3e6c86d"), "Pizza", "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ", "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.", "Party BBQ", 480.0, 0.0, false },
                    { new Guid("488af474-209e-4f69-a02c-6ede596b1c53"), "Wok", "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.", "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok а-ля Диаблo", 330.0, 5.0, false },
                    { new Guid("be46a77b-c51b-4d4b-b319-8c8cc513f9e6"), "Wok", "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.", "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с курицей", 280.0, 0.0, false },
                    { new Guid("e3c13cdc-9589-4cfd-8a03-1bc700e6afdc"), "Wok", "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.", "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok болоньезе", 290.0, 0.0, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StorageTokens");

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("233dd476-de88-46c5-b231-f54f0f929fac"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("47c18313-0aae-48ae-be77-2522b3e6c86d"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("488af474-209e-4f69-a02c-6ede596b1c53"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("be46a77b-c51b-4d4b-b319-8c8cc513f9e6"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e3c13cdc-9589-4cfd-8a03-1bc700e6afdc"));

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
    }
}

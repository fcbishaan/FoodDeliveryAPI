using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vashishth_Backened._24.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("2347dd00-48f6-41b0-8070-3acffde9cad4"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("7c41f85c-54d9-422a-96d6-5e5a305dd235"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9392114c-c7dd-448f-9520-dfaafda338af"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e8d6bf49-5594-43b7-ae0b-892ae1a6ddf2"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("f4d75291-8406-4833-abb8-c0f51763733a"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    deliveryTime = table.Column<string>(type: "text", nullable: false),
                    OrderTime = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    userId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

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

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Rating", "Vegetarian" },
                values: new object[,]
                {
                    { new Guid("2347dd00-48f6-41b0-8070-3acffde9cad4"), "Pizza", "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы", "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.", "4 сыра", 360.0, 4.0, true },
                    { new Guid("7c41f85c-54d9-422a-96d6-5e5a305dd235"), "Wok", "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.", "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok болоньезе", 290.0, 0.0, false },
                    { new Guid("9392114c-c7dd-448f-9520-dfaafda338af"), "Wok", "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.", "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok а-ля Диаблo", 330.0, 5.0, false },
                    { new Guid("e8d6bf49-5594-43b7-ae0b-892ae1a6ddf2"), "Wok", "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.", "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с курицей", 280.0, 0.0, false },
                    { new Guid("f4d75291-8406-4833-abb8-c0f51763733a"), "Pizza", "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ", "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.", "Party BBQ", 480.0, 0.0, false }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vashishth_Backened._24.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("080eb6db-ba70-4a0d-a1d8-aa256e492c98"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("919fec4d-d483-4c93-a5cd-69b39a157405"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("bd88aa3b-0c90-4d8f-9a70-67e424b03420"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("c9f53d7a-4928-47c4-9443-a518ad6f7718"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("d39a9739-eb70-4d76-b055-b6b27f20ef0e"));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Rating", "Vegetarian" },
                values: new object[,]
                {
                    { new Guid("0b1daecf-bfc2-4027-974b-e09ba360996e"), "Wok", "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.", "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok а-ля Диаблo", 330.0, 5.0, false },
                    { new Guid("9912d828-1d92-4eca-bf84-2dd956015426"), "Pizza", "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ", "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.", "Party BBQ", 480.0, 0.0, false },
                    { new Guid("b29fad2e-2369-4f1b-8faa-48f5549ef412"), "Wok", "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.", "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с курицей", 280.0, 0.0, false },
                    { new Guid("e1ff5493-32ca-4262-9e5d-cc492527aa4e"), "Wok", "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.", "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok болоньезе", 290.0, 0.0, false },
                    { new Guid("fbcbe645-31d3-4804-887c-d75e601763fa"), "Pizza", "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы", "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.", "4 сыра", 360.0, 4.0, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("0b1daecf-bfc2-4027-974b-e09ba360996e"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9912d828-1d92-4eca-bf84-2dd956015426"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("b29fad2e-2369-4f1b-8faa-48f5549ef412"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e1ff5493-32ca-4262-9e5d-cc492527aa4e"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("fbcbe645-31d3-4804-887c-d75e601763fa"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Rating", "Vegetarian" },
                values: new object[,]
                {
                    { new Guid("080eb6db-ba70-4a0d-a1d8-aa256e492c98"), "Wok", "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.", "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok болоньезе", 290.0, 0.0, false },
                    { new Guid("919fec4d-d483-4c93-a5cd-69b39a157405"), "Pizza", "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ", "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.", "Party BBQ", 480.0, 0.0, false },
                    { new Guid("bd88aa3b-0c90-4d8f-9a70-67e424b03420"), "Wok", "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.", "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok а-ля Диаблo", 330.0, 5.0, false },
                    { new Guid("c9f53d7a-4928-47c4-9443-a518ad6f7718"), "Wok", "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.", "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с курицей", 280.0, 0.0, false },
                    { new Guid("d39a9739-eb70-4d76-b055-b6b27f20ef0e"), "Pizza", "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы", "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.", "4 сыра", 360.0, 4.0, true }
                });
        }
    }
}

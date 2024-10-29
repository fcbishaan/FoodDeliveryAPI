using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vashishth_Backened._24.Migrations
{
    /// <inheritdoc />
    public partial class updateuserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("1c56b7d2-af84-4b11-b9ee-da3e185f96bf"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("3f21c54a-b1e3-46d5-8ff1-9867b9bf0768"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("b8e4844a-c8bd-4461-a53f-5f9008e4151d"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("c1d4a00c-ac81-4f0d-961f-fa082ef93f5e"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("d9ccc671-11de-4af2-a981-13abb3de8906"));
            
              migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            // Add the new UUID Id column with auto-generated GUIDs
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Baskets",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Baskets",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

        // Drop the UUID Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            // Re-add the integer Id column with identity
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "Baskets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Baskets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Rating", "Vegetarian" },
                values: new object[,]
                {
                    { new Guid("1c56b7d2-af84-4b11-b9ee-da3e185f96bf"), "Pizza", "4 сыра: «Моцарелла», «Гауда», «Фета», «Дор-блю», сливочно-сырный соус, пряные травы", "https://mistertako.ru/uploads/products/77888c7e-8327-11ec-8575-0050569dbef0.", "4 сыра", 360.0, 4.0, true },
                    { new Guid("3f21c54a-b1e3-46d5-8ff1-9867b9bf0768"), "Wok", "Пшеничная лапша обжаренная на воке с колбасками пепперони, маслинами, сладким перцем и перцем халапеньо в томатном соусе с добавлением петрушки.", "https://mistertako.ru/uploads/products/663ab868-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok а-ля Диаблo", 330.0, 5.0, false },
                    { new Guid("b8e4844a-c8bd-4461-a53f-5f9008e4151d"), "Wok", "Лапша пшеничная, куриное филе, шампиньоны, лук красный, заправка Том Ям.", "https://mistertako.ru/uploads/products/a41bd9fd-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с курицей", 280.0, 0.0, false },
                    { new Guid("c1d4a00c-ac81-4f0d-961f-fa082ef93f5e"), "Wok", "Пшеничная лапша обжаренная на воке с фаршем (Говядина/свинина) и овощами.", "https://mistertako.ru/uploads/products/663ab866-85ec-11ea-a9ab-86b1f8341741.jpg", "Wok болоньезе", 290.0, 0.0, false },
                    { new Guid("d9ccc671-11de-4af2-a981-13abb3de8906"), "Pizza", "Бекон, соленый огурчик, брусника, сыр «Моцарелла», сыр «Гауда», соус BBQ", "https://mistertako.ru/uploads/products/839d0250-8327-11ec-8575-0050569dbef0.", "Party BBQ", 480.0, 0.0, false }
                });
        }
    }
}

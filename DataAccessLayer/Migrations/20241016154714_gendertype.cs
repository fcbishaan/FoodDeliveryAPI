using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vashishth_Backened._24.Migrations
{
    public partial class UpdateUserWithGenderEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Add the new Gender column (allow NULL temporarily)
            migrationBuilder.AddColumn<int>(
                name: "NewGender",
                table: "Users",
                type: "integer",
                nullable: true); // Allow NULL initially

            // Step 2: Update NewGender based on existing Gender values
            migrationBuilder.Sql(
                "UPDATE \"Users\" SET \"NewGender\" = CASE " +
                "WHEN \"Gender\" = 'Male' THEN 0 " +
                "WHEN \"Gender\" = 'Female' THEN 1 " +
                "WHEN \"Gender\" = 'Other' THEN 2 " +
                "ELSE 0 END;"); // Default to 0 (Male) if Gender is NULL or invalid

            // Step 3: Drop the old Gender column
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            // Step 4: Rename NewGender to Gender
            migrationBuilder.RenameColumn(
                name: "NewGender",
                table: "Users",
                newName: "Gender");

            // Step 5: Set the new Gender column to NOT NULL
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true); // Now enforce NOT NULL
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Recreate the old Gender column as a string
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "Male");

            // Step 2: Migrate data back to the old column
            migrationBuilder.Sql(
                "UPDATE \"Users\" SET \"Gender\" = CASE " +
                "WHEN \"Gender\" = 0 THEN 'Male' " +
                "WHEN \"Gender\" = 1 THEN 'Female' " +
                "WHEN \"Gender\" = 2 THEN 'Other' " +
                "ELSE 'Male' END;"); // Default to Male

            // Step 3: Drop the new Gender column
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            // Step 4: Rename old column back to Gender
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "Gender");
        }
    }
}

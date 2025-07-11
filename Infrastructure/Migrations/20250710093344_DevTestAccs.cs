using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DevTestAccs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthTimestamp", "Email", "ExtraNeeds", "FirstName", "LastName", "Notes", "PasswordHash", "PhoneNumber", "PhotoPath", "RoleId" },
                values: new object[,]
                {
                    { 2L, 0L, "jean.doe@gmail.com", null, "Jean", "Doe", null, null, null, null, 2L },
                    { 3L, 0L, "marie.lala@hotmail.fr", null, "Marie", "Lala", null, null, null, null, 1L },
                    { 4L, 0L, "mlock@gmail.com", null, "Mark", "Lock", null, null, null, null, 3L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}

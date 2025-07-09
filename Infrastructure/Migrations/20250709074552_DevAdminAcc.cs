using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DevAdminAcc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthTimestamp", "Email", "ExtraNeeds", "FirstName", "LastName", "Notes", "PasswordHash", "PhoneNumber", "PhotoPath", "RoleId" },
                values: new object[] { 1L, 0L, "email@email.com", null, "Admin", "Admin", null, null, null, null, 4L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAcessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedSomeCustmore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St", "john@example.com", "John Doe", "1234567890" },
                    { 2, "456 Park Ave", "jane@example.com", "Jane Smith", "9876543210" },
                    { 3, "Cairo, Egypt", "ali@example.com", "Ali Hassan", "01011223344" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

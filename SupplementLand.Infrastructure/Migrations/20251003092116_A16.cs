using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplementLand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class A16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEKWqixEjjLgh5PRQwx3+KQ1pIghXBRUstP41kfD6XOQZS5j88NQyjdQYjErPql812A==");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEPKfmfPjzOJ4oKD+f6Rqn4AxJxJuPAviXoMbnDhzbHkOsq6UNIC7SN/KYlNCLaNxhw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAECloGdv82auBqxcbm+sGVVRj4LFo5iBc4VXXLHNHazxJJzPdfNI005W9nWq7NVjByw==");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAELdQm0scGi/LDWXGfeMEfX0I95exy1qfAke+8JGjHjOjWGNFH9FtcPhB18c4Q0N2XA==");
        }
    }
}

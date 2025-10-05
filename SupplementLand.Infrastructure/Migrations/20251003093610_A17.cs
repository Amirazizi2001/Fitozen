using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplementLand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class A17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAEC/BSAorTfsY05zmYrxLfZcSZwNPxrefMTZG+FpaNMa21dpmsC6JdRwSakg0NfZEhw==", "o4N0YWnqgI8CqqLqvB+MZfV83gokJj4o7xkNxx5soKk=" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAEJNME87MijZLIdO+1aArEI9ZalQlQ4eSdqku7aHHLDKzPClQgY4YBmObHcFIiaMrDw==", "v5A3cXc7dpn5f0uDkQmL3ZThmLQXgb7F6t7+07r2iNk=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAEKWqixEjjLgh5PRQwx3+KQ1pIghXBRUstP41kfD6XOQZS5j88NQyjdQYjErPql812A==", "FixedToken1234567890==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAEPKfmfPjzOJ4oKD+f6Rqn4AxJxJuPAviXoMbnDhzbHkOsq6UNIC7SN/KYlNCLaNxhw==", "FixedToken1234567890==" });
        }
    }
}

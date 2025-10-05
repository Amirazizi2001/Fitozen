using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplementLand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class A18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAECCT9d0jjVEVHup8xnSlICD5W70LpVWpUK7JDxzm13by/5DY9YWhQqlGRlFqvZvVCw==");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEAB1m2MwA1aqpNTOovEJPwzh/KM2F5QIUja/3RcYUcRGstUyI6BtG2aWQIu9q4UMCw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEC/BSAorTfsY05zmYrxLfZcSZwNPxrefMTZG+FpaNMa21dpmsC6JdRwSakg0NfZEhw==");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEJNME87MijZLIdO+1aArEI9ZalQlQ4eSdqku7aHHLDKzPClQgY4YBmObHcFIiaMrDw==");
        }
    }
}

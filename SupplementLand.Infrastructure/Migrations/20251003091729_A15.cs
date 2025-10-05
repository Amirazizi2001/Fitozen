using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplementLand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class A15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAECloGdv82auBqxcbm+sGVVRj4LFo5iBc4VXXLHNHazxJJzPdfNI005W9nWq7NVjByw==", "FixedToken1234567890==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAELdQm0scGi/LDWXGfeMEfX0I95exy1qfAke+8JGjHjOjWGNFH9FtcPhB18c4Q0N2XA==", "FixedToken1234567890==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAEAgGLU3BnhrD1s9+S2viOJhN/+yPEaJW69T3KkSpOyH9WYX3kp2neB5gilv2DEQD2g==", "cOpLNpXB604GJ1aJdMWN/u/+65V1FPR6qLSf5t+KgWc=" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAELs1tEo37EaKsvvgQzC/2NwMiLKdtZ572bTEQ1IfIBDhU/nYsNArojxdRCrhBELxkg==", "Y01ZD64QPiYL00KsRbbC5frdbDGYikbwAy+vIHiQgqY=" });
        }
    }
}

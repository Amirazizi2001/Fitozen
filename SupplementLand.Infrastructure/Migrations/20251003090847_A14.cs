using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplementLand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class A14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAEFlcHrJ34385vh6PgPfHT48HyJ9ri7vAImRUEq3+tIJUV6woA3GVfkrDXkwyGPLGww==", "N8binIAk/FAILez46kAg4Feu3zccJCsUVWkMxBlG2XE=" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "RefreshToken" },
                values: new object[] { "AQAAAAIAAYagAAAAEKvS2e/rubfgzR5P/j+D/HyQbtIOP8AXzKfg4H3gUaUxuWNc+Ir5R0HcZ0dIrdjclg==", "UIwCbHS3e9yuDoKNvhPGO/MH+oA+KqH1r+No/k7ZQ7w=" });
        }
    }
}

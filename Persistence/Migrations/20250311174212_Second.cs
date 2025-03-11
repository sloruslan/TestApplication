using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "USER",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "USER",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "ROLE",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Admin" },
                    { 2L, "User" }
                });

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "id", "email", "first_name", "Password", "patronymic", "RoleId", "second_name" },
                values: new object[,]
                {
                    { 1L, "admin@mail.ru", "Ivan", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", "Ivanovich", 1L, "Ivanov" },
                    { 2L, "user@mail.ru", "Semen", "04F8996DA763B7A969B1028EE3007569EAF3A635486DDAB211D512C85B9DF8FB", "Semenovich", 2L, "Semenov" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_USER_RoleId",
                table: "USER",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_USER_ROLE_RoleId",
                table: "USER",
                column: "RoleId",
                principalTable: "ROLE",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USER_ROLE_RoleId",
                table: "USER");

            migrationBuilder.DropIndex(
                name: "IX_USER_RoleId",
                table: "USER");

            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ROLE",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ROLE",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "USER");
        }
    }
}

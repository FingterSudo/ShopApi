using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogin",
                table: "UserLogin");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "UserLogin",
                type: "varbinary(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "UserLogin",
                type: "varbinary(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserLogin",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USERLOGIN",
                table: "UserLogin",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Roles = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERROLES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USERROLES_REFERENCE_USERLOGINS",
                        column: x => x.UserId,
                        principalTable: "UserLogin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IndexUserRolesUserId",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USERLOGIN",
                table: "UserLogin");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "UserLogin",
                type: "varbinary(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "UserLogin",
                type: "varbinary(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserLogin",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogin",
                table: "UserLogin",
                column: "Id");
        }
    }
}

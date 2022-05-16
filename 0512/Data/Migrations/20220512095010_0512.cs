using Microsoft.EntityFrameworkCore.Migrations;

namespace _0512.Data.Migrations
{
    public partial class _0512 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aru",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Beszallito = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ar = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aru", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aru");
        }
    }
}

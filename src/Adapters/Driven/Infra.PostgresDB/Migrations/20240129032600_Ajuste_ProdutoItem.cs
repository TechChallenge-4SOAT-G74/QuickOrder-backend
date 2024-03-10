using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickOrder.Adapters.Driven.PostgresDB.Migrations
{
    public partial class Ajuste_ProdutoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Item",
                table: "ProdutoItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Item",
                table: "ProdutoItem",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}

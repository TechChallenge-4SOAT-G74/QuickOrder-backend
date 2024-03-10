using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickOrder.Adapters.Driven.PostgresDB.Migrations
{
    public partial class ajustepedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cliente",
                table: "Pedido",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CarrinhoId",
                table: "Pedido",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "Cliente",
                table: "Pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}

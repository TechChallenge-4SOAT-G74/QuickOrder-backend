using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuickOrder.Adapters.Driven.PostgresDB.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoItem = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    QuantidadeItem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<double>(type: "double precision", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Foto = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Produto = table.Column<int>(type: "integer", nullable: false),
                    Item = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeMin = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeMax = table.Column<int>(type: "integer", nullable: false),
                    PermitidoAlterar = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoItem_Item_Item",
                        column: x => x.Item,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoItem_Produto_Produto",
                        column: x => x.Produto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DDD = table.Column<string>(type: "varchar(15)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario_Usuario",
                        column: x => x.Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Matricula = table.Column<int>(type: "integer", nullable: false),
                    Usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Usuario_Usuario",
                        column: x => x.Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroPedido = table.Column<int>(type: "integer", nullable: false),
                    DataHoraInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataHoraFinalizado = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cliente = table.Column<int>(type: "integer", nullable: false),
                    ValorPedido = table.Column<double>(type: "double precision", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    PedidoPago = table.Column<bool>(type: "boolean", nullable: false),
                    ProdutoItemPedidoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_Cliente",
                        column: x => x.Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoItemPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PordutoItem = table.Column<int>(type: "integer", nullable: false),
                    Pedido = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoItemPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoItemPedido_Pedido_Pedido",
                        column: x => x.Pedido,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoItemPedido_ProdutoItem_PordutoItem",
                        column: x => x.PordutoItem,
                        principalTable: "ProdutoItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Usuario",
                table: "Cliente",
                column: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Usuario",
                table: "Funcionario",
                column: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Cliente",
                table: "Pedido",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ProdutoItemPedidoId",
                table: "Pedido",
                column: "ProdutoItemPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItem_Item",
                table: "ProdutoItem",
                column: "Item");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItem_Produto",
                table: "ProdutoItem",
                column: "Produto");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItemPedido_Pedido",
                table: "ProdutoItemPedido",
                column: "Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItemPedido_PordutoItem",
                table: "ProdutoItemPedido",
                column: "PordutoItem");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_ProdutoItemPedido_ProdutoItemPedidoId",
                table: "Pedido",
                column: "ProdutoItemPedidoId",
                principalTable: "ProdutoItemPedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Usuario_Usuario",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_Cliente",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_ProdutoItemPedido_ProdutoItemPedidoId",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ProdutoItemPedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "ProdutoItem");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}

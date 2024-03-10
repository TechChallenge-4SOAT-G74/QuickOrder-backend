using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickOrder.Adapters.Driven.PostgresDB.Migrations
{
    public partial class insertinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO ""Produto"" (""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") 
                    VALUES 
                ('Big Mag', 1, 20, 'Dois hambúrgueres (100% carne bovina), alface americana, queijo sabor cheddar, molho especial, cebola, picles e pão com gergelim.'),
	            ('McFritas Grande', 2, 9, 'A batata frita mais famosa do mundo. Deliciosas batatas selecionadas, fritas, crocantes por fora, macias por dentro, douradas, irresistíveis, saborosas, famosas, e todos os outros adjetivos positivos que você quiser dar.'),
                ('Coca-Cola 500ml', 3, 7, 'Refrescante e geladinha. Uma bebida assim refresca a vida. Você pode escolher entre Coca-Cola, Coca-Cola Zero, Sprite sem Açúcar, Fanta Guaraná e Fanta Laranja.'),
                ('Sundae morango', 4, 9, 'A medida certa entre cobertura de morango e bebida láctea sabor baunilha que pode fazer você viver uma experiência explosiva, além de amendoins crocantes. Desfrute dessa combinação perfeita!'),
                ('Chicken McNuggets 10 unidades', 1, 12, 'Crocantes, leves e deliciosos. Os frangos empanados mais irresistíveis do McDonald’s.'),
	            ('Torta de maçã', 4, 7, 'Boa demais. Parece a receita lá de casa. Massa quentinha e crocante envolvendo deliciosos recheios de banana ou maçã com gostinho de doce caseiro.'),
                ('Casquinha baunilha', 4, 6, 'A sobremesa que o Brasil todo adora. Uma casquinha supercrocante, com bebida láctea sabor baunilha que vai bem a qualquer hora.'),
                ('Quarterão com Queijo', 1, 19, 'Um hambúrguer (100% carne bovina), queijo sabor cheddar, picles, cebola, ketchup, mostarda e pão com gergelim.'),
                ('McShake Ovomaltine', 4, 12, 'Deliciosamente cremoso. O novo McShake Ovomaltine é feito com leite e batido na hora. Uma delícia!'),
                ('Pão de Queijo', 1, 6, 'Impossível de resistir. Pão de queijo quentinho e macio. Quem já provou sabe que não tem igual.'),
                ('Iced Mix Café', 3, 8, 'O sabor é tão refrescante quanto delicioso. Feito com o saboroso espresso do McCafé em uma combinação com a nossa bebida láctea sabor baunilha batido com pedras de gelo, finalizado chocolate em pó polvilhado.');

                INSERT INTO ""Usuario"" (""Nome"", ""Cpf"", ""Email"", ""Status"", ""Role"") VALUES ('Ronald McDonald', '43149620031', 'ronald@mcdonalds.com', true, 5);

                INSERT INTO ""Cliente"" (""DDD"", ""Telefone"", ""DataNascimento"", ""Usuario"") VALUES ('21', '99999-9999', '01/01/1963', 1);"
                );

        }

    }
}

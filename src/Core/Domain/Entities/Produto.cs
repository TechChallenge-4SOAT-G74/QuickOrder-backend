using QuickOrder.Core.Domain.Adapters.Base;
using QuickOrder.Core.Domain.Entities.Base;
using QuickOrder.Core.Domain.ValueObjects;

namespace QuickOrder.Core.Domain.Entities
{
    public class Produto : EntityBase, IAggregateRoot
    {
        protected Produto() { }
        public Produto(string nome, int categoriaId, double preco, string? descricao = null, string? foto = null, List<ProdutoItem>? produtoItens = null)
        {
            Nome = new NomeVo(nome);
            CategoriaId = categoriaId;
            Preco = preco;
            Descricao = descricao;
            Foto = foto;
            ProdutoItens = produtoItens;


            ValidaPreco();
        }

        public virtual NomeVo Nome { get; set; }
        public virtual int CategoriaId { get; set; }
        public virtual double Preco { get; set; }
        public virtual string? Descricao { get; set; }
        public virtual string? Foto { get; set; }


        public virtual List<ProdutoItem>? ProdutoItens { get; set; }

        public bool Any()
        {
            throw new NotImplementedException();
        }


        public void ValidaPreco()
        {
            if (this.ProdutoItens != null)
            {
                var quantidadeItens = 0;
                var valorItens = 0.0;
                var valorProduto = 0.0;

                foreach (var pi in this.ProdutoItens.ToList())
                {
                    quantidadeItens += pi.Quantidade;
                    valorItens += pi.Item.Valor;

                    valorProduto = valorItens * quantidadeItens;
                }

                this.Preco = this.Preco < valorProduto ? valorProduto : this.Preco;
            }
        }
    }
}

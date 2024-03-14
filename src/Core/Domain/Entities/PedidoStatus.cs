using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuickOrder.Core.Domain.Entities
{
    public class PedidoStatus
    {
        public PedidoStatus(int numeroPedido, string statusPedido, DateTime dataAtualizacao)
        {
            NumeroPedido = numeroPedido;
            StatusPedido = statusPedido;
            DataAtualizacao = dataAtualizacao;
        }

        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public int NumeroPedido { get; set; }
        public string StatusPedido { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int StatusOrdem { get; set; }
    }
}

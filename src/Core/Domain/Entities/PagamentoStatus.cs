using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuickOrder.Core.Domain.Entities
{
    public class PagamentoStatus
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public int NumeroPedido { get; set; }
        public int? clienteId { get; set; }
        public double Valor { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string? StatusPagamento { get; set; }
        public string? ProvedorPagamento { get; set; }
        public string? ChavePagamento { get; set; }
        public string? QrCodePayment { get; set; }
    }
}

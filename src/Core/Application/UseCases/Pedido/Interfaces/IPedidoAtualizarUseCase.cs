using QuickOrder.Adapters.Driven.MercadoPago.Responses;
using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Core.Application.UseCases.Pedido.Interfaces
{
    public interface IPedidoAtualizarUseCase : IBaseUseCase
    {
        Task<ServiceResult> AlterarItemAoPedido(string id, List<ProdutoCarrinho> pedidoDto);
        Task<ServiceResult<PaymentQrCodeResponse>> ConfirmarPedido(int id);
        Task<ServiceResult> ConfirmarPagamentoPedido(int id);
        Task<ServiceResult> AlterarStatusPedido(int id, string pedidoStatus);
    }
}

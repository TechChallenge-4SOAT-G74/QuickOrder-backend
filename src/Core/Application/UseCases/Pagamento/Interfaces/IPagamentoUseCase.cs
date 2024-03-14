using QuickOrder.Adapters.Driven.MercadoPago.Requests;
using QuickOrder.Adapters.Driven.MercadoPago.Responses;
using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Pagamento.Interfaces
{
    public interface IPagamentoUseCase : IBaseUseCase
    {
        Task VerificaPagamento(WebHookData whData);
        Task<bool> AtualizarStatusPagamento(string numeroPedido, int statusPagamento);
        Task<ServiceResult<PaymentQrCodeResponse>> GerarQrCodePagamento(int idPedido);
    }
}

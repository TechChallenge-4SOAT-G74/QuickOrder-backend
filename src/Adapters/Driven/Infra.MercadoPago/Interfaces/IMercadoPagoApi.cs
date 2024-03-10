using QuickOrder.Adapters.Driven.MercadoPago.Requests;
using QuickOrder.Adapters.Driven.MercadoPago.Responses;

namespace QuickOrder.Adapters.Driven.MercadoPago.Interfaces
{
    public interface IMercadoPagoApi
    {
        Task<PaymentQrCodeResponse> GeraQrCodePagamento(PaymentQrCodeRequest request);
        Task<Payment> ObterPagamento(string id);
    }
}

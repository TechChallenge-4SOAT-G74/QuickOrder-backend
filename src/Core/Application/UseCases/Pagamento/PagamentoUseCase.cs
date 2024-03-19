using QuickOrder.Adapters.Driven.MercadoPago.Interfaces;
using QuickOrder.Adapters.Driven.MercadoPago.Requests;
using QuickOrder.Adapters.Driven.MercadoPago.Responses;
using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Enums;
using ItemRequest = QuickOrder.Adapters.Driven.MercadoPago.Requests.Item;

namespace QuickOrder.Core.Application.UseCases.Pagamento
{
    public class PagamentoUseCase : IPagamentoUseCase
    {
        private readonly IPagamentoStatusGateway _statusGateway;
        private readonly IPedidoObterUseCase _pedidoObterUseCase;
        private readonly IMercadoPagoApi _mercadoPagoApi;
        private readonly IPedidoStatusGateway _pedidoStatusGateway;

        public PagamentoUseCase(IPagamentoStatusGateway statusGateway, IPedidoObterUseCase pedidoObterUseCase, IMercadoPagoApi mercadoPagoApi, IPedidoStatusGateway pedidoStatusGateway)
        {
            _statusGateway = statusGateway;
            _pedidoObterUseCase = pedidoObterUseCase;
            _mercadoPagoApi = mercadoPagoApi;
            _pedidoStatusGateway = pedidoStatusGateway;
        }

        public async Task VerificaPagamento(WebHookData whData)
        {
            var retorno = await _mercadoPagoApi.ObterPagamento(whData.Data.Id);

            var status = 0;
            switch (retorno.Status)
            {
                case "approved":
                    status = (int)EStatusPagamento.Aprovado;
                    break;
                case "pending":
                    status = (int)EStatusPagamento.aguardando;
                    break;
                case "authorized":
                    status = (int)EStatusPagamento.processando;
                    break;
                case "in_process":
                    status = (int)EStatusPagamento.processando;
                    break;
                case "in_mediation":
                    status = (int)EStatusPagamento.processando;
                    break;
                case "rejected":
                    status = (int)EStatusPagamento.Negado;
                    break;
                case "cancelled":
                    status = (int)EStatusPagamento.Negado;
                    break;
                case "refunded":
                    status = (int)EStatusPagamento.Negado;
                    break;
                case "charged_back":
                    status = (int)EStatusPagamento.Negado;
                    break;
            }

            await AtualizarStatusPagamento(whData.Data.Id, status);
        }


        public async Task<bool> AtualizarStatusPagamento(string numeroPedido, int statusPagamento)
        {
            var pedido = await _statusGateway.GetValue("NumeroPedido", numeroPedido);

            if (pedido != null)
            {
                var pagamentoStatus = new PagamentoStatus
                {
                    Id = pedido.Id,
                    NumeroPedido = pedido.NumeroPedido,
                    clienteId = pedido.clienteId,
                    StatusPagamento = EStatusPagamentoExtensions.ToDescriptionString((EStatusPagamento)statusPagamento),
                    DataAtualizacao = DateTime.Now
                };
                _statusGateway.Update(pagamentoStatus);

                if ((EStatusPagamento)statusPagamento == EStatusPagamento.Aprovado)
                {
                    var pedidoStatus = new PedidoStatus((int)Convert.ToUInt32(pedido.NumeroPedido), EStatusPedidoExtensions.ToDescriptionString(EStatusPedido.Recebido), DateTime.Now);
                    _pedidoStatusGateway.Update(pedidoStatus);
                }

            }

            return true;
        }

        private async Task EnviarPedidoPagamento(SacolaDto sacolaDto, PaymentQrCodeResponse paymentQrCode)
        {
            var pagamentoStatus = new PagamentoStatus
            {
                clienteId = (int?)Convert.ToUInt32(sacolaDto.NumeroCliente),
                NumeroPedido = (int)Convert.ToUInt32(sacolaDto.NumeroPedido),
                DataAtualizacao = DateTime.Now,
                Valor = sacolaDto.Valor,
                StatusPagamento = EStatusPagamentoExtensions.ToDescriptionString(EStatusPagamento.aguardando),
                ProvedorPagamento = "Mercado Pago",
                ChavePagamento = paymentQrCode.in_store_order_id,
                QrCodePayment = paymentQrCode.qr_data
            };
            await _statusGateway.Create(pagamentoStatus);

            var pedidoStatus = new PedidoStatus((int)Convert.ToUInt32(sacolaDto.NumeroPedido), EStatusPedidoExtensions.ToDescriptionString(EStatusPedido.PendentePagamento), DateTime.Now);
            _pedidoStatusGateway.Update(pedidoStatus);
        }

        public async Task<ServiceResult<PaymentQrCodeResponse>> GerarQrCodePagamento(int idPedido)
        {
            var result = new ServiceResult<PaymentQrCodeResponse>();

            try
            {
                var pedido = await _pedidoObterUseCase.ConsultarPedido(idPedido);

                if (pedido == null)
                {
                    result.AddError("Pedido não localizado.");
                    return result;
                }

                var request = new PaymentQrCodeRequest
                {
                    description = $"Pedido {pedido.Data.NumeroCliente}",
                    external_reference = pedido.Data.NumeroPedido.ToString(),
                    items = new List<ItemRequest>()
                    {
                        new ItemRequest
                        {
                            title = $"Pedido {pedido.Data.NumeroCliente}",
                            unit_price = Convert.ToInt32(pedido.Data.ValorPedido),
                            quantity = 1,
                            unit_measure = "unit",
                            total_amount = Convert.ToInt32(pedido.Data.ValorPedido),
                        },
                    },
                    title = "Product order",
                    total_amount = Convert.ToInt32(pedido.Data.ValorPedido),
                };

                if (Convert.ToInt32(pedido.Data.ValorPedido) == 0)
                {
                    result.AddError("Pedido não possui valor para pagamento.");
                    return result;
                }

                var response = _mercadoPagoApi.GeraQrCodePagamento(request);

                var sacolaDto = new SacolaDto
                {
                    NumeroCliente = pedido.Data.NumeroCliente.ToString(),
                    NumeroPedido = pedido.Data.NumeroPedido.ToString(),
                    Valor = Convert.ToInt32(pedido.Data.ValorPedido)
                };

                await EnviarPedidoPagamento(sacolaDto, response.Result);

                result.Data = response.Result;
            }
            catch (Exception ex)
            {
                result.AddError(400, ex.Message);
            }

            return result;
        }
    }
}

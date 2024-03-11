using QuickOrder.Adapters.Driven.MercadoPago.Responses;
using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using ProdutosItemsPedidoEntity = QuickOrder.Core.Domain.Entities.ProdutoItemPedido;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public class PedidoAtualizarUseCase : IPedidoAtualizarUseCase
    {
        private readonly IPedidoGateway _pedidoGateway;
        private readonly ICarrinhoGateway _carrinhoGateway;
        private readonly IPedidoStatusGateway _pedidoStatusGateway;
        public readonly IPagamentoUseCase _pagamentoUseCase;

        public PedidoAtualizarUseCase(IPedidoGateway pedidoGateway, ICarrinhoGateway carrinhoGateway, IPedidoStatusGateway pedidoStatusGateway, IPagamentoUseCase pagamentoUseCase)
        {
            _pedidoGateway = pedidoGateway;
            _carrinhoGateway = carrinhoGateway;
            _pedidoStatusGateway = pedidoStatusGateway;
            _pagamentoUseCase = pagamentoUseCase;
        }

        public async Task<ServiceResult> AlterarItemAoPedido(string id, List<ProdutoCarrinho> produtoCarrinho)
        {
            var result = new ServiceResult();
            try
            {
                var carrinho = await _carrinhoGateway.GetValue("NumeroPedido", id);

                if (carrinho == null)
                {
                    result.AddError("Pedido não localizado.");
                    return result;
                }

                carrinho.DataAtualizacao = DateTime.Now;
                carrinho.Valor = produtoCarrinho.Sum(x => x.ValorProduto);
                carrinho.ProdutosCarrinho = produtoCarrinho;

                _carrinhoGateway.Update(carrinho);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> AlterarStatusPedido(int id, string pedidoStatus)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoStatusGateway.GetValue("NumeroPedido", id.ToString());

                if (pedido == null)
                {
                    result.AddError("Pedido não localizado.");
                    return result;
                }

                pedido.StatusPedido = pedidoStatus;
                pedido.DataAtualizacao = DateTime.Now;
                _pedidoStatusGateway.Update(pedido);

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> ConfirmarPagamentoPedido(int id)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoGateway.GetFirst(id);

                if (pedido == null)
                {
                    result.AddError("Pedido não localizado.");
                    return result;
                }

                pedido.PedidoPago = true;

                await _pedidoGateway.Update(pedido);

                var sacolaDto = new SacolaDto { NumeroCliente = pedido.ClienteId.ToString(), NumeroPedido = pedido.NumeroPedido.ToString(), CarrinhoId = pedido.CarrinhoId, Valor = pedido.ValorPedido };
                await _pagamentoUseCase.AtualizarStatusPagamento(pedido.NumeroPedido.ToString(), (int)EStatusPagamento.Aprovado);

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<PaymentQrCodeResponse>> ConfirmarPedido(int id)
        {
            var result = new ServiceResult<PaymentQrCodeResponse>();
            try
            {
                var pedido = await _pedidoGateway.GetFirst(id);
                var carrinho = await _carrinhoGateway.GetValue("NumeroPedido", id.ToString());

                if (pedido == null || carrinho == null)
                {
                    result.AddError("Pedido não localizado.");
                    return result;
                }

                var produtosItems = new List<ProdutosItemsPedidoEntity>();

                foreach (var item in carrinho.ProdutosCarrinho)
                    produtosItems.Add(new ProdutosItemsPedidoEntity(new ProdutoItem(item.IdProduto, 1), id));

                pedido.ProdutosItemsPedido = produtosItems;
                pedido.ValorPedido = carrinho.ProdutosCarrinho.Sum(x => x.ValorProduto);

                await _pedidoGateway.Update(pedido);

                var pedidoStatusExiste = await _pedidoStatusGateway.GetValue("NumeroPedido", id.ToString());

                if (pedidoStatusExiste == null)
                {
                    var pedidoStatus = new PedidoStatus(
                        pedido.NumeroPedido,
                        EStatusPedidoExtensions.ToDescriptionString(EStatusPedido.PendentePagamento),
                        DateTime.Now);

                    await _pedidoStatusGateway.Create(pedidoStatus);
                }
                else
                {
                    pedidoStatusExiste.StatusPedido = EStatusPedidoExtensions.ToDescriptionString(EStatusPedido.PendentePagamento);
                    _pedidoStatusGateway.Update(pedidoStatusExiste);
                }

                result = await _pagamentoUseCase.GerarQrCodePagamento(pedido.NumeroPedido);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

    }
}

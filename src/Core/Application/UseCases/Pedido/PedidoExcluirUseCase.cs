using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public class PedidoExcluirUseCase : IPedidoExcluirUseCase
    {
        private readonly IPedidoGateway _pedidoGateway;
        private readonly ICarrinhoGateway _carrinhoGateway;
        private readonly IPedidoStatusGateway _pedidoStatusGateway;

        public PedidoExcluirUseCase(IPedidoGateway pedidoGateway, ICarrinhoGateway carrinhoGateway, IPedidoStatusGateway pedidoStatusGateway)
        {
            _pedidoGateway = pedidoGateway;
            _carrinhoGateway = carrinhoGateway;
            _pedidoStatusGateway = pedidoStatusGateway;
        }

        public async Task<ServiceResult> CancelarPedido(string carrinhoId)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoGateway.GetFirst(x => x.CarrinhoId.Equals(carrinhoId));

                if (pedido == null)
                {
                    result.AddError("Pedido não encontrado.");
                    return result;
                }
                await _pedidoGateway.Delete(pedido.Id);

                if (pedido.CarrinhoId != null)
                {
                    var carrinho = await _carrinhoGateway.Get(pedido.CarrinhoId);
                    if (carrinho != null)
                        _carrinhoGateway.Delete(carrinho.Id.ToString());

                    var status = await _pedidoStatusGateway.GetValue("CarrinhoId", pedido.CarrinhoId);
                    if (status != null)
                        _pedidoStatusGateway.Delete(status.Id.ToString());
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}

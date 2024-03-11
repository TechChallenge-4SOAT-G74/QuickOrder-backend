using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using PedidoEntity = QuickOrder.Core.Domain.Entities.Pedido;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public class PedidoCriarUseCase : IPedidoCriarUseCase
    {
        private readonly IPedidoGateway _pedidoGateway;
        private readonly IClienteGateway _clienteGateway;
        private readonly ICarrinhoGateway _carrinhoGateway;
        private readonly IPedidoStatusGateway _pedidoStatusGateway;

        public PedidoCriarUseCase(IPedidoGateway pedidoGateway, IClienteGateway clienteGateway, ICarrinhoGateway carrinhoGateway, IPedidoStatusGateway pedidoStatusGateway)
        {
            _pedidoGateway = pedidoGateway;
            _clienteGateway = clienteGateway;
            _carrinhoGateway = carrinhoGateway;
            _pedidoStatusGateway = pedidoStatusGateway;
        }

        public async Task<ServiceResult> CriarPedido(int? numeroCliente = null)
        {
            //TODO: Usaundo número do cliente como parametro até cria a autenticação.

            var result = new ServiceResult();
            try
            {

                var numeroPedido = _pedidoGateway.GetAll().Result.Select(x => x.Id).OrderByDescending(x => x).FirstOrDefault() + 1;
                var carrinho = new Carrinho(numeroPedido, numeroCliente, 0, DateTime.Now, null);
                var pedido = new PedidoEntity(numeroPedido, DateTime.Now, null, numeroCliente, carrinho.Id.ToString(), null, 0, false);
                var pedidoStatus = new PedidoStatus(numeroPedido, EStatusPedidoExtensions.ToDescriptionString(EStatusPedido.Criado), DateTime.Now);

                await _carrinhoGateway.Create(carrinho);
                await _pedidoStatusGateway.Create(pedidoStatus);
                await _pedidoGateway.Insert(pedido);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}

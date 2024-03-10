using QuickOrder.Core.Application.Dtos;
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
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;

        public PedidoCriarUseCase(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository, ICarrinhoRepository carrinhoRepository, IPedidoStatusRepository pedidoStatusRepository)
        {
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
            _carrinhoRepository = carrinhoRepository;
            _pedidoStatusRepository = pedidoStatusRepository;
        }

        public async Task<ServiceResult> CriarPedido(int? numeroCliente = null)
        {
            //TODO: Usaundo número do cliente como parametro até cria a autenticação.

            var result = new ServiceResult();
            try
            {

                var numeroPedido = _pedidoRepository.GetAll().Result.Select(x => x.Id).OrderByDescending(x => x).FirstOrDefault() + 1;
                var carrinho = new Carrinho(numeroPedido, numeroCliente, 0, DateTime.Now, null);
                var pedido = new PedidoEntity(numeroPedido, DateTime.Now, null, numeroCliente, carrinho.Id.ToString(), null, 0, false);
                var pedidoStatus = new PedidoStatus(numeroPedido, EStatusPedidoExtensions.ToDescriptionString(EStatusPedido.Criado), DateTime.Now);

                await _carrinhoRepository.Create(carrinho);
                await _pedidoStatusRepository.Create(pedidoStatus);
                await _pedidoRepository.Insert(pedido);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}

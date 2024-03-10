using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Core.Application.UseCases.Pedido.Interfaces
{
    public interface IPedidoObterUseCase : IBaseUseCase
    {
        Task<ServiceResult<PedidoDto>> ConsultarPedido(int id);
        Task<ServiceResult<PagamentoDto>> ConsultarStatusPagamentoPedido(int id);
        Task<ServiceResult<List<PedidoStatus>>> ConsultarFilaPedidos();
        Task<ServiceResult<List<PedidoDto>>> ConsultarListaPedidos();
    }
}

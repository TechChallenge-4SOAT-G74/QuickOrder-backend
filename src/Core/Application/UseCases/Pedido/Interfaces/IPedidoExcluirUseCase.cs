using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Pedido.Interfaces
{
    public interface IPedidoExcluirUseCase : IBaseUseCase
    {
        Task<ServiceResult> CancelarPedido(string carrinhoId);
    }
}

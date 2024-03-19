using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Pedido.Interfaces
{
    public interface IPedidoExcluirUseCase : IBaseUseCase
    {
        Task<ServiceResult> CancelarPedido(string carrinhoId);
    }
}

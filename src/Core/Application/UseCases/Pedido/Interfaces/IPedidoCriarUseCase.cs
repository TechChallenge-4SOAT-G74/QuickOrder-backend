using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Pedido.Interfaces
{
    public interface IPedidoCriarUseCase : IBaseUseCase
    {
        Task<ServiceResult> CriarPedido(int? numeroCliente = null);
    }
}

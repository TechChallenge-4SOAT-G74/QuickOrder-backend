using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Pedido.Interfaces
{
    public interface IPedidoCriarUseCase : IBaseUseCase
    {
        Task<ServiceResult> CriarPedido(int? numeroCliente = null);
    }
}

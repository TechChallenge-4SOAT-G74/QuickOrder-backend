using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Cliente.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Cliente
{
    public class ClienteExcluirUseCase : IClienteExcluirUseCase
    {
        private readonly IClienteGateway _clienteGateway;

        public ClienteExcluirUseCase(IClienteGateway clienteGateway)
        {
            _clienteGateway = clienteGateway;
        }

        public async Task<ServiceResult> Execute(int id)
        {
            ServiceResult result = new();
            try
            {
                var clienteExiste = await _clienteGateway.GetFirst(id);

                if (clienteExiste == null)
                {
                    result.AddError("cliente não encontrado.");
                    return result;
                }
                await _clienteGateway.Delete(id);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}

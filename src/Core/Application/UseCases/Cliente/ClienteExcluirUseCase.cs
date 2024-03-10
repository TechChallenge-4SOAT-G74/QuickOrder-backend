using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Cliente.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Cliente
{
    public class ClienteExcluirUseCase : IClienteExcluirUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteExcluirUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ServiceResult> Execute(int id)
        {
            ServiceResult result = new();
            try
            {
                var clienteExiste = await _clienteRepository.GetFirst(id);

                if (clienteExiste == null)
                {
                    result.AddError("cliente não encontrado.");
                    return result;
                }
                await _clienteRepository.Delete(id);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}

using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Cliente.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using ClienteEntity = QuickOrder.Core.Domain.Entities.Cliente;
using UsuarioEntity = QuickOrder.Core.Domain.Entities.Usuario;

namespace QuickOrder.Core.Application.UseCases.Cliente
{
    public class ClienteCriarUseCase : IClienteCriarUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCriarUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ServiceResult> Execute(ClienteDto clienteDto)
        {
            ServiceResult result = new();
            try
            {
                var clienteExiste = await _clienteRepository.GetClienteByCpfOrEmail(clienteDto.Cpf, clienteDto.Email);
                if (clienteExiste != null)
                {
                    result.AddError("Cliente já existe.");
                    return result;
                }

                var usuario = new UsuarioEntity(clienteDto.Nome, clienteDto.Cpf, clienteDto.Email, true, (int)ERole.Cliente);
                var cliente = new ClienteEntity(clienteDto.DDD, clienteDto.Telefone, clienteDto?.DataNascimento, usuario);

                var clienteInsert = await _clienteRepository.Insert(cliente);

            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}

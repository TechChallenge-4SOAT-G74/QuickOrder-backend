using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Cliente.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using QuickOrder.Core.Domain.ValueObjects;
using UsuarioEntity = QuickOrder.Core.Domain.Entities.Usuario;

namespace QuickOrder.Core.Application.UseCases.Cliente
{
    public class ClienteAtualizarUseCase : IClienteAtualizarUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAtualizarUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ServiceResult> Execute(ClienteDto clienteDto, int id)
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

                var usuario = new UsuarioEntity(clienteDto.Nome, clienteDto.Cpf, clienteDto.Email, true, (int)ERole.Cliente);

                clienteExiste.Telefone = new TelefoneVo(clienteDto.DDD, clienteDto.Telefone);
                clienteExiste.DataNascimento = clienteDto?.DataNascimento;
                clienteExiste.Usuario = usuario;

                await _clienteRepository.Update(clienteExiste);

            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}

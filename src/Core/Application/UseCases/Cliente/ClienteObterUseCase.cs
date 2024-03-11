using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Cliente.Interfaces;
using QuickOrder.Core.Domain.Repositories;
using System.Runtime.InteropServices;

namespace QuickOrder.Core.Application.UseCases.Cliente
{
    public class ClienteObterUseCase : IClienteObterUseCase
    {
        private readonly IClienteGateway _clienteGateway;

        public ClienteObterUseCase(IClienteGateway clienteGateway)
        {
            _clienteGateway = clienteGateway;
        }

        public async Task<ServiceResult<List<ClienteDto>>> Execute()
        {
            ServiceResult<List<ClienteDto>> result = new();
            try
            {
                var clientes = await _clienteGateway.GetAllClienteComUsuario(x => x.Usuario.Status);

                var list = new List<ClienteDto>();

                foreach (var cliente in clientes)
                {
                    list.Add(new ClienteDto
                    {
                        Nome = cliente.Usuario.Nome.Nome,
                        Cpf = cliente.Usuario.Cpf.CodigoCpf,
                        Email = cliente.Usuario.Email.Endereco,
                        DDD = cliente.Telefone.DDD,
                        Telefone = cliente.Telefone.Numero,
                        DataNascimento = cliente.DataNascimento,
                        Status = cliente.Usuario.Status
                    });
                }

                result.Data = list;
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }

        public async Task<ServiceResult<ClienteDto>> Execute(int id)
        {
            ServiceResult<ClienteDto> result = new();
            try
            {
                var cliente = await _clienteGateway.GetClienteById(id);
                result.Data = new ClienteDto
                {
                    Nome = cliente.Usuario.Nome.Nome,
                    Cpf = cliente.Usuario.Cpf.CodigoCpf,
                    Email = cliente.Usuario.Email.Endereco,
                    DDD = cliente.Telefone.DDD,
                    Telefone = cliente.Telefone.Numero,
                    DataNascimento = cliente.DataNascimento,
                    Status = cliente.Usuario.Status
                };
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }

}

using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Funcionario.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using UsuarioEntity = QuickOrder.Core.Domain.Entities.Usuario;

namespace QuickOrder.Core.Application.UseCases.Funcionario
{
    public class FuncionarioAtualizarUseCase : IFuncionarioAtualizarUseCase
    {
        private readonly IFuncionarioGateway _funcionarioGateway;

        public FuncionarioAtualizarUseCase(IFuncionarioGateway funcionarioGateway)
        {
            _funcionarioGateway = funcionarioGateway;
        }

        public async Task<ServiceResult> Execute(FuncionarioDto funcionarioDto, int id)
        {
            ServiceResult result = new();
            try
            {
                var funcionarioExiste = await _funcionarioGateway.GetFirst(id);

                if (funcionarioExiste == null)
                {
                    result.AddError("Funcionario não encontrado.");
                    return result;
                }
                var usuario = new UsuarioEntity(funcionarioDto.Nome, funcionarioDto.Cpf, funcionarioDto.Email, funcionarioDto.Status, (int)(ERole)Enum.Parse(typeof(ERole), funcionarioDto.Role));
                funcionarioExiste.Matricula = funcionarioDto.Matricula;
                funcionarioExiste.Usuario = usuario;


                await _funcionarioGateway.Update(funcionarioExiste);

            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}

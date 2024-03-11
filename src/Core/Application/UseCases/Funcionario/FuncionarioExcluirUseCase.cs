using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Funcionario.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Funcionario
{
    public class FuncionarioExcluirUseCase : IFuncionarioExcluirUseCase
    {
        private readonly IFuncionarioGateway _funcionarioGateway;

        public FuncionarioExcluirUseCase(IFuncionarioGateway funcionarioGateway)
        {
            _funcionarioGateway = funcionarioGateway;
        }

        public async Task<ServiceResult> Execute(int id)
        {
            ServiceResult result = new();
            try
            {
                var UsuarioExiste = await _funcionarioGateway.GetFirst(id);

                if (UsuarioExiste == null)
                {
                    result.AddError("Usuario não encontrado.");
                    return result;
                }
                await _funcionarioGateway.Delete(id);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}

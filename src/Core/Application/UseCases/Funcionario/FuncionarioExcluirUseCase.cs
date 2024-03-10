using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Funcionario.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Funcionario
{
    public class FuncionarioExcluirUseCase : IFuncionarioExcluirUseCase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioExcluirUseCase(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<ServiceResult> Execute(int id)
        {
            ServiceResult result = new();
            try
            {
                var UsuarioExiste = await _funcionarioRepository.GetFirst(id);

                if (UsuarioExiste == null)
                {
                    result.AddError("Usuario não encontrado.");
                    return result;
                }
                await _funcionarioRepository.Delete(id);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}

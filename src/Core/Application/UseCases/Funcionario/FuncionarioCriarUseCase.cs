using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Funcionario.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using FuncionarioEntity = QuickOrder.Core.Domain.Entities.Funcionario;
using UsuarioEntity = QuickOrder.Core.Domain.Entities.Usuario;

namespace QuickOrder.Core.Application.UseCases.Funcionario
{
    public class FuncionarioCriarUseCase : IFuncionarioCriarUseCase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioCriarUseCase(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<ServiceResult> Execute(FuncionarioDto funcionarioDto)
        {
            ServiceResult result = new();
            try
            {
                var funcionarioExiste = await _funcionarioRepository.GetFirst(x => x.Usuario.Nome.Equals(funcionarioDto.Nome) && x.Usuario.Cpf.Equals(funcionarioDto.Cpf));
                if (funcionarioExiste != null)
                {
                    result.AddError("funcionario já existe.");
                    return result;
                }
                var matricula = new Random().Next(1, 6);
                var usuario = new UsuarioEntity(funcionarioDto.Nome, funcionarioDto.Cpf, funcionarioDto.Email, true, (int)(ERole)Enum.Parse(typeof(ERole), funcionarioDto.Role));
                var funcionario = new FuncionarioEntity(matricula, usuario);

                var funcionarioInsert = await _funcionarioRepository.Insert(funcionario);

            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}

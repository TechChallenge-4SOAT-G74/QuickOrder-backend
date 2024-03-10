using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Funcionario.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Funcionario
{
    public class FuncionarioObterUseCase : IFuncionarioObterUseCase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioObterUseCase(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<ServiceResult<List<FuncionarioDto>>> Execute()
        {
            ServiceResult<List<FuncionarioDto>> result = new();
            try
            {
                var funcionarios = await _funcionarioRepository.GetAll(x => x.Usuario.Status);

                var list = new List<FuncionarioDto>();

                foreach (var funcionario in funcionarios)
                {
                    list.Add(new FuncionarioDto
                    {
                        Matricula = funcionario.Matricula,
                        Nome = funcionario.Usuario.Nome.Nome,
                        Cpf = funcionario.Usuario.Cpf.CodigoCpf,
                        Email = funcionario.Usuario.Email.Endereco,
                        Role = ERoleExtensions.ToDescriptionString((ERole)funcionario.Usuario.Role),
                    });
                }


                result.Data = list;
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }

        public async Task<ServiceResult<FuncionarioDto>> Execute(int id)
        {
            ServiceResult<FuncionarioDto> result = new();
            try
            {
                var funcionario = await _funcionarioRepository.GetFirst(x => x.Usuario.Status && x.Id.Equals(id));
                result.Data = new FuncionarioDto
                {
                    Matricula = funcionario.Matricula,
                    Nome = funcionario.Usuario.Nome.Nome,
                    Cpf = funcionario.Usuario.Cpf.CodigoCpf,
                    Email = funcionario.Usuario.Email.Endereco,
                    Role = ERoleExtensions.ToDescriptionString((ERole)funcionario.Usuario.Role),
                };
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }

}

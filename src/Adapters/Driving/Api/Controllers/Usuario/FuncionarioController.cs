using Microsoft.AspNetCore.Mvc;
using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Funcionario.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickOrder.Adapters.Driving.Api.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : CustomController<FuncionarioController>
    {
        private readonly IFuncionarioObterUseCase _usuarioObterUseCase;
        private readonly IFuncionarioCriarUseCase _usuarioCriarUseCase;
        private readonly IFuncionarioAtualizarUseCase _usuarioatualizarUseCase;
        private readonly IFuncionarioExcluirUseCase _usuarioExcluirUseCase;

        public FuncionarioController(ILogger<FuncionarioController> logger,
           IFuncionarioObterUseCase usuarioObterUseCase,
           IFuncionarioCriarUseCase usuarioCriarUseCase,
           IFuncionarioAtualizarUseCase usuarioatualizarUseCase,
           IFuncionarioExcluirUseCase usuarioExcluirUseCase) : base(logger)
        {
            _usuarioObterUseCase = usuarioObterUseCase;
            _usuarioCriarUseCase = usuarioCriarUseCase;
            _usuarioatualizarUseCase = usuarioatualizarUseCase;
            _usuarioExcluirUseCase = usuarioExcluirUseCase;
        }

        /// <summary>
        /// Obter lista de Usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Get()
        {
            return Result(await _usuarioObterUseCase.Execute());
        }

        /// <summary>
        /// Obter Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Get(int id)
        {
            return Result(await _usuarioObterUseCase.Execute(id));
        }

        /// <summary>
        /// Criar Usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Post([FromBody] FuncionarioDto usuario)
        {
            return Result(await _usuarioCriarUseCase.Execute(usuario));
        }

        /// <summary>
        /// Atualizar Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        [HttpPut("{id}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Put([FromBody] FuncionarioDto usuario, int id)
        {
            return Result(await _usuarioatualizarUseCase.Execute(usuario, id));
        }


        /// <summary>
        /// Excluir Usuario
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Delete(int id)
        {
            return Result(await _usuarioExcluirUseCase.Execute(id));
        }
    }
}

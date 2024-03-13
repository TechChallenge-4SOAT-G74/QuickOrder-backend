using Microsoft.AspNetCore.Mvc;
using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Cliente.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickOrder.Adapters.Driving.Api.Controllers.cliente
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : CustomController<ClienteController>
    {
        private readonly IClienteObterUseCase _clienteObterUseCase;
        private readonly IClienteCriarUseCase _clienteCriarUseCase;
        private readonly IClienteAtualizarUseCase _clienteatualizarUseCase;
        private readonly IClienteExcluirUseCase _clienteExcluirUseCase;

        public ClienteController(ILogger<ClienteController> logger,
           IClienteObterUseCase clienteObterUseCase,
           IClienteCriarUseCase clienteCriarUseCase,
           IClienteAtualizarUseCase clienteatualizarUseCase,
           IClienteExcluirUseCase clienteExcluirUseCase) : base(logger)
        {
            _clienteObterUseCase = clienteObterUseCase;
            _clienteCriarUseCase = clienteCriarUseCase;
            _clienteatualizarUseCase = clienteatualizarUseCase;
            _clienteExcluirUseCase = clienteExcluirUseCase;
        }

        /// <summary>
        /// Obter lista de clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Get()
        {
            return Result(await _clienteObterUseCase.Execute());
        }

        /// <summary>
        /// Obter cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Get(int id)
        {
            return Result(await _clienteObterUseCase.Execute(id));
        }

        /// <summary>
        /// Criar cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Post([FromBody] ClienteDto cliente)
        {
            return Result(await _clienteCriarUseCase.Execute(cliente));
        }

        /// <summary>
        /// Atualizar cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        [HttpPut("{id}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Put([FromBody] ClienteDto cliente, int id)
        {
            return Result(await _clienteatualizarUseCase.Execute(cliente, id));
        }


        /// <summary>
        /// Excluir cliente
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Delete(int id)
        {
            return Result(await _clienteExcluirUseCase.Execute(id));
        }
    }
}

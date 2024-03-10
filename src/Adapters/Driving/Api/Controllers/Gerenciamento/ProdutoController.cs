using Microsoft.AspNetCore.Mvc;
using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickOrder.Adapters.Driving.Api.Controllers.Gerenciamento
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : CustomController<ProdutoController>
    {
        private readonly IProdutoObterUseCase _produtoObterUseCase;
        private readonly IProdutoCriarUseCase _produtoCriarUseCase;
        private readonly IProdutoAtualizarUseCase _produtoAtualizarUseCase;
        private readonly IProdutoExcluirUseCase _produtoExcluirUseCase;

        public ProdutoController(ILogger<ProdutoController> logger,
           IProdutoObterUseCase produtoObterUseCase,
           IProdutoCriarUseCase produtoCriarUseCase,
           IProdutoAtualizarUseCase produtoAtualizarUseCase,
           IProdutoExcluirUseCase produtoExcluirUseCase) : base(logger)
        {
            _produtoObterUseCase = produtoObterUseCase;
            _produtoCriarUseCase = produtoCriarUseCase;
            _produtoAtualizarUseCase = produtoAtualizarUseCase;
            _produtoExcluirUseCase = produtoExcluirUseCase;
        }

        /// <summary>
        /// Obter lista de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Result(await _produtoObterUseCase.Execute());
        }

        /// <summary>
        /// Obter produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Result(await _produtoObterUseCase.Execute(id));
        }

        /// <summary>
        /// Criar Produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDto produto)
        {
            return Result(await _produtoCriarUseCase.Execute(produto));
        }

        /// <summary>
        /// Atualizar Produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produto"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ProdutoDto produto, int id)
        {
            return Result(await _produtoAtualizarUseCase.Execute(produto, id));
        }


        /// <summary>
        /// Excluir produto
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Result(await _produtoExcluirUseCase.Execute(id));
        }
    }
}

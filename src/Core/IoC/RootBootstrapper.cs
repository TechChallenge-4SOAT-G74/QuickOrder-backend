using Microsoft.Extensions.DependencyInjection;
using QuickOrder.Adapters.Driven.MercadoPago;
using QuickOrder.Adapters.Driven.MercadoPago.Interfaces;
using QuickOrder.Adapters.Driven.MongoDB.Core;
using QuickOrder.Adapters.Driven.MongoDB.Repositories;
using QuickOrder.Adapters.Driven.PostgresDB.Repositories;
using QuickOrder.Core.Application.UseCases;
using QuickOrder.Core.Application.UseCases.Cliente;
using QuickOrder.Core.Application.UseCases.Cliente.Interfaces;
using QuickOrder.Core.Application.UseCases.Funcionario;
using QuickOrder.Core.Application.UseCases.Funcionario.Interfaces;
using QuickOrder.Core.Application.UseCases.Pagamento;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Application.UseCases.Pedido;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Application.UseCases.Produto;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.IoC
{
    public static class RootBootstrapper
    {
        public static void BootstrapperRegisterServices(this IServiceCollection services)
        {
            var assemblyTypes = typeof(RootBootstrapper).Assembly.GetNoAbstractTypes();

            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseRepository), assemblyTypes);

            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseUseCase), assemblyTypes);

            //Repositories postgresDB
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddScoped<IProdutoItemPedidoRepository, ProdutoItemPedidoRepository>();
            services.AddScoped<IProdutoItemRepository, ProdutoItemRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Repositories MongoDB
            services.AddSingleton<IMondoDBContext, MondoDBContext>();
            services.AddScoped<IPedidoStatusRepository, PedidoStatusRepository>();
            services.AddScoped<IPagamentoStatusRepository, PagamentoStatusRepository>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();


            //UseCases
            services.AddScoped<IProdutoAtualizarUseCase, ProdutoAtualizarUseCase>();
            services.AddScoped<IProdutoExcluirUseCase, ProdutoExcluirUseCase>();
            services.AddScoped<IProdutoCriarUseCase, ProdutoCriarUseCase>();
            services.AddScoped<IProdutoObterUseCase, ProdutoObterUseCase>();

            services.AddScoped<IFuncionarioAtualizarUseCase, FuncionarioAtualizarUseCase>();
            services.AddScoped<IFuncionarioExcluirUseCase, FuncionarioExcluirUseCase>();
            services.AddScoped<IFuncionarioCriarUseCase, FuncionarioCriarUseCase>();
            services.AddScoped<IFuncionarioObterUseCase, FuncionarioObterUseCase>();

            services.AddScoped<IClienteAtualizarUseCase, ClienteAtualizarUseCase>();
            services.AddScoped<IClienteExcluirUseCase, ClienteExcluirUseCase>();
            services.AddScoped<IClienteCriarUseCase, ClienteCriarUseCase>();
            services.AddScoped<IClienteObterUseCase, ClienteObterUseCase>();

            services.AddScoped<IPedidoAtualizarUseCase, PedidoAtualizarUseCase>();
            services.AddScoped<IPedidoExcluirUseCase, PedidoExcluirUseCase>();
            services.AddScoped<IPedidoCriarUseCase, PedidoCriarUseCase>();
            services.AddScoped<IPedidoObterUseCase, PedidoObterUseCase>();

            services.AddScoped<IPagamentoUseCase, PagamentoUseCase>();

            services.AddScoped<IMercadoPagoApi, MercadoPagoApi>();
        }
    }
}

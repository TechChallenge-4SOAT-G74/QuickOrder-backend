
using QuickOrder.Core.IoC;

namespace QuickOrder.Adapters.Driving.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            RootBootstrapper.BootstrapperRegisterServices(services);
        }
    }
}

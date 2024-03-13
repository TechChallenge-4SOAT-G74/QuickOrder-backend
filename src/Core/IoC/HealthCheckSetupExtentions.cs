using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using QuickOrder.Core.Domain.Entities.Base;

namespace QuickOrder.Core.IoC
{
    public static class HealthCheckSetupExtentions
    {
        public static void ConfigureHealthCheckEndpoints(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthCheck", new HealthCheckOptions()
            {
                Predicate = (_) => false,
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                }
            });
        }

        public static void ConfigureHealthChecks(
            this IServiceCollection services
            , DatabaseMongoDBSettings configurationMongo
            , DatabaseSettings configurationPostgres)
        {
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy("healthCheck OK!"))
                .AddNpgSql(
                    npgsqlConnectionString: configurationPostgres.ConnectionString,
                    name: "Postgres - QuickOrderDB",
                    timeout: TimeSpan.FromSeconds(29))
                .AddMongoDb(
                    mongodbConnectionString: configurationMongo.ConnectionString,
                    mongoDatabaseName: configurationMongo.DatabaseName,
                    name: configurationMongo.ConnectionString, //"Mongo - QuickOrderDB",
                    timeout: TimeSpan.FromSeconds(29));


        }
    }
}

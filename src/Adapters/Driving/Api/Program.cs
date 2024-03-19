using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Adapters.Driving.Api.Configurations;
using QuickOrder.Core.Domain.Entities.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings")
);

builder.Services.Configure<DatabaseMongoDBSettings>(
    builder.Configuration.GetSection("DatabaseMongoDBSettings")
);

builder.Services.Configure<MercadoPagoSettings>(
    builder.Configuration.GetSection("MercadoPagoSettings")
);


var migrationsAssembly = typeof(ApplicationContext).Assembly.GetName().Name;
var migrationTable = "__IntegradorPlurallMigrationsHistory";

//===================================================================================================

DatabaseSettings databaseSettings = new DatabaseSettings();

var secretName = "postgres-db-secret_1";
var region = "us-east-1"; // ou a região onde seu segredo está armazenado

var client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

var request = new GetSecretValueRequest
{
    SecretId = Environment.GetEnvironmentVariable("DB_SECRET_ARN")
};

var response = await client.GetSecretValueAsync(request);
var secretString = response.SecretString;


// Analise o JSON secretString para extrair as credenciais do banco de dados
var secretJson = JObject.Parse(secretString);

var postgresConnectionString = $"Server={secretJson["host"]};Port=5432;Database={secretJson["dbname"]};User ID={secretJson["username"]};Password={secretJson["password"]};";


builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(postgresConnectionString, b =>
    {
        b.MigrationsAssembly(migrationsAssembly);
        b.MigrationsHistoryTable(migrationTable);
    });

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
});

//===================================================================================================

builder.Services.AddSingleton<IMongoDatabase>(options =>
{
    DatabaseMongoDBSettings settings = new DatabaseMongoDBSettings();
    string mongo = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_MONGODB");

    if (!string.IsNullOrEmpty(mongo))
    {
        settings.DatabaseName = "quickorderdb";
        settings.ConnectionString = mongo;
    }
    else
        databaseSettings = builder.Configuration.GetSection("DatabaseMongoDBSettings").Get<DatabaseMongoDBSettings>();

    var client = new MongoClient(settings.ConnectionString);

    return client.GetDatabase(settings.DatabaseName);
});

//===================================================================================================

builder.Services.AddDependencyInjectionConfiguration();

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .WithOrigins("http://localhost:8090");
                      });
});


builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuickOrder.Api", Version = "v1" });
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseReDoc(c =>
{
    c.DocumentTitle = "QuickOrder API Documentation";
    c.SpecUrl = "/swagger/v1/swagger.json";
});

//app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

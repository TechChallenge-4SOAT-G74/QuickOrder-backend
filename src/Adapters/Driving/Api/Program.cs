using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Adapters.Driving.Api.Configurations;
using QuickOrder.Core.Domain.Entities;

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
var databaseSettings = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(databaseSettings.ConnectionString, b =>
    {
        b.MigrationsAssembly(migrationsAssembly);
        b.MigrationsHistoryTable(migrationTable);
    });

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
});

builder.Services.AddSingleton<IMongoDatabase>(options =>
{
    var settings = builder.Configuration.GetSection("DatabaseMongoDBSettings").Get<DatabaseMongoDBSettings>();
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

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

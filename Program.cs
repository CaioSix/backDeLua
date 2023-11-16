using AutoMapper;
using DeLua.Config;
using DeLua.Context;
using DeLua.Contracts;
using DeLua.Processo;
using DeLua.Repository;
using DeLua.Service;
using Microsoft.AspNetCore.Hosting;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);







// Adicione os serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configurações
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IProductProcess, ProductProcess>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

// Configuração CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Adicione o middleware CORS antes de outros middlewares
app.UseCors("AnyOrigin");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

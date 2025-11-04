using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PayFlow.Application.UseCases;
using PayFlow.Domain.Ports;
using PayFlow.Domain.Services;
using PayFlow.Infrastructure.Providers;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependências
builder.Services.AddSingleton<FastPayFeeCalculator>();
builder.Services.AddSingleton<SecurePayFeeCalculator>();
builder.Services.AddScoped<IProviderPort, FastPayAdapter>();
builder.Services.AddScoped<IProviderPort, SecurePayAdapter>();
builder.Services.AddTransient<ProcessPaymentUseCase>();

var app = builder.Build();

// Habilitar Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PayFlow API v1");
    c.RoutePrefix = string.Empty; // Swagger na raiz
});

// Middlewares
app.UseAuthorization();
app.MapControllers();

app.Run();

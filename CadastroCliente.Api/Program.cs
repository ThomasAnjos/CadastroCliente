using Core.Entitites;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Dto;
using Infrastructure.Interface;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Usuario>();
builder.Services.AddScoped<List<Usuario>>();
builder.Services.AddScoped<UsuarioDto>();
builder.Services.AddScoped<List<UsuarioDto>>();

builder.Services.AddScoped<ClienteDto>();
builder.Services.AddScoped<List<ClienteDto>>();
builder.Services.AddScoped<Cliente>();
builder.Services.AddScoped<List<Cliente>>();

builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

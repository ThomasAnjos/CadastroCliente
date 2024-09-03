using CadastroCliente.Application.Interface;
using CadastroCliente.Application.Models;
using CadastroCliente.Application.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<HttpResponseMessage>();
builder.Services.AddScoped<List<ApplicationUsuario>>();
builder.Services.AddScoped<ApplicationUsuario>();
builder.Services.AddScoped<List<ApplicationCliente>>();
builder.Services.AddScoped<ApplicationCliente>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

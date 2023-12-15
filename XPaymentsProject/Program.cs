using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using XPaymentsProject.Application.Interfaces;
using XPaymentsProject.Application.Services;
using XPaymentsProject.Data;
using XPaymentsProject.Domain.Interfaces;
using XPaymentsProject.Infra.Context;
using XPaymentsProject.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
// Adicionado a classe de contexto do banco de dados
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionado os serviços do produto a injeção de dependencia
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
builder.Services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();
builder.Services.AddScoped<IAutenticacaoApplicationService, AutenticacaoApplicationService>();
builder.Services.AddMudServices();
builder.Services.AddMudBlazorJsEvent();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


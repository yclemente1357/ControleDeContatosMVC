using ControleDeContatos.Data;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços de MVC ao aplicativo.
builder.Services.AddControllersWithViews();

// Configura o Entity Framework Core com SQL Server.
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<BancoContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));


// Registra os repositórios no sistema de DI.
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

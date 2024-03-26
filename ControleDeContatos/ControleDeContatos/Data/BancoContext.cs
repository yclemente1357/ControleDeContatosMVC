using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ControleDeContatos.Data;

public class BancoContext : DbContext
{

    public BancoContext() { 

    }

    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            var conexaoStr = "Server=DESKTOP-VU2RJ44\\SQLEXPRESS;Database=DB_SistemaContatos;Trusted_Connection=True;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(conexaoStr);
        }
    }

    public DbSet<ContatoModel> Contato { get; set; }
}

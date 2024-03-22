using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data;

public class BancoContext : DbContext
{
    protected BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }

    public DbSet<ContatoModel> Contato { get; set; }
}

using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio;

public class ContatoRepositorio : IContatoRepositorio
{

    private readonly BancoContext _bancoContext;
    public ContatoRepositorio(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    public List<ContatoModel> BuscarTodos()
    {
        return _bancoContext.Contato.ToList();
    }

    public ContatoModel Adicionar(ContatoModel contato)
    {
        _bancoContext.Contato.Add(contato);
        _bancoContext.SaveChanges();
        return contato;
    }
}

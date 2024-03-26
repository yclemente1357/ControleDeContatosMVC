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
    public ContatoModel Atualiza(ContatoModel contato)
    {
        ContatoModel contatoDB = ListarPorId(contato.Id);

        if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato! ");
        contatoDB.Nome = contato.Nome;
        contatoDB.Email = contato.Email;
        contatoDB.Celular = contato.Celular;

        _bancoContext.Contato.Update(contatoDB);
        _bancoContext.SaveChanges();

        return contatoDB;
    }
    public ContatoModel ListarPorId(int id)
    {
        return _bancoContext.Contato.FirstOrDefault(x => x.Id == id);
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

    public bool Apagar(int id)
    {
        ContatoModel contatoDB = ListarPorId(id);
        if (contatoDB == null) throw new System.Exception("Houve um erro na deleção do contato! ");

        _bancoContext.Contato.Remove(contatoDB);
        _bancoContext.SaveChanges();

        return true;
    }
}

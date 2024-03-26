using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio;

public interface IContatoRepositorio
{
    bool Apagar(int id );
    ContatoModel ListarPorId(int id);
    List<ContatoModel> BuscarTodos();
    ContatoModel Adicionar(ContatoModel contato);
    ContatoModel Atualiza(ContatoModel contato);
}

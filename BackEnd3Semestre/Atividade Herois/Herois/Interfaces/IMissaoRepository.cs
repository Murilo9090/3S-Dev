using Herois.Models;

namespace HeroisAPI.Interfaces;

public interface IMissaoRepository
{
    void Cadastrar(Missao missao);
    List<Missao> Listar();
    void Deletar(Guid id);
    void Atualizar(Guid id, Missao missao);
    Missao BuscarPorId(Guid id);
}
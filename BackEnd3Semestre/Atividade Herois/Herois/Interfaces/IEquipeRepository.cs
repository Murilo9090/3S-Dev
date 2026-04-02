using Herois.Models;

namespace HeroisAPI.Interfaces;

public interface IEquipeRepository
{
    void Cadastrar(Equipe equipe);
    List<Equipe> Listar();
    void Deletar(Guid id);
    void Atualizar(Guid id, Equipe equipe);
    Equipe BuscarPorId(Guid id);
}
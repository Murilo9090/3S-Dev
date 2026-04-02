using Herois.Models;

namespace HeroisAPI.Interfaces;

public interface IHeroiRepository
{
    void Cadastrar(Heroi heroi);
    List<Heroi> Listar();
    void Deletar(Guid id);
    void Atualizar(Guid id, Heroi heroi);
    Heroi BuscarPorId(Guid id);
}
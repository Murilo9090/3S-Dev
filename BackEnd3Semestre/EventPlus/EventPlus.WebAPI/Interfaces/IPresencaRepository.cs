using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IPresencaRepository
    {
        void Inscrever(Presenca Inscricao);
        void Deletar(Guid Id);

        List<Presenca> Listar();
        Presenca BuscarPorId(Guid Id);
        void Atualizar(Guid id, Presenca presenca);
        List<Presenca> ListarMinhas(Guid IdUsuario);
    }
}

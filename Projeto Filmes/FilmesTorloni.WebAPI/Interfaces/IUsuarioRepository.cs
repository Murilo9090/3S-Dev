using FilmesTorloni.WebAPI.Models;

namespace FilmesTorloni.WebAPI.Interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario novoUsuario);
    Usuario BuscarPorId(Guid Id);
    Usuario BuscarPorEmailESenha(string Email, string senha);
}

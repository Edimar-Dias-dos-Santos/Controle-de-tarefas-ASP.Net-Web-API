using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IRepUsuario
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int Id);
        Task<UsuarioModel> Adcionar(UsuarioModel usuario);
        Task<UsuarioModel>Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}

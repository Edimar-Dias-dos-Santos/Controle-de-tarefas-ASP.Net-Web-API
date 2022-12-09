using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class RepUsuario : IRepUsuario
    {
        private readonly SistemaTarefasDbContex _sistemaTarefasDbContex;
        public RepUsuario(SistemaTarefasDbContex sistemaTarefasDbContex)
        {
            _sistemaTarefasDbContex = sistemaTarefasDbContex;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _sistemaTarefasDbContex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _sistemaTarefasDbContex.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adcionar(UsuarioModel usuario)
        {
           await _sistemaTarefasDbContex.Usuarios.AddAsync(usuario);
           await _sistemaTarefasDbContex.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _sistemaTarefasDbContex.Update(usuarioPorId);
           await _sistemaTarefasDbContex.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            _sistemaTarefasDbContex.Remove(usuarioPorId);
            await _sistemaTarefasDbContex.SaveChangesAsync();

            return await _sistemaTarefasDbContex.Usuarios.AnyAsync(x => x.Id == id) ? false : true;
        }
    }
}

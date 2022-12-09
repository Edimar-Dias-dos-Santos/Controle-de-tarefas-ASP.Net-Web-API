using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IRepUsuario _repUsuario;

        public UsuarioController(IRepUsuario repUsuario)
        {
            _repUsuario = repUsuario;
        }

        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<List<UsuarioModel>>> ListarUsuarios()
        {
            List<UsuarioModel> usuarios = await _repUsuario.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _repUsuario.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost("CadastrarUsuario")]
        public async Task<ActionResult<UsuarioModel>> CadastrarUsuario([FromBody] UsuarioModel usuario)
        {
           UsuarioModel usuariioModel = await _repUsuario.Adcionar(usuario);
           return Ok(usuariioModel);
        }

        [HttpPut ("AtualizarUsuario/{id}")]
        public async Task<ActionResult<UsuarioModel>> AtualizarUsuario([FromBody] UsuarioModel usuario, int id)
        {
            usuario.Id = id;
            UsuarioModel usuariioModel = await _repUsuario.Atualizar(usuario, id);
            return Ok(usuariioModel);
        }

        [HttpDelete("DeletarUsuario/{id}")]
        public async Task<ActionResult<UsuarioModel>> DeletarUsuario(int id)
        {
            bool deletado = await _repUsuario.Apagar(id);
            return Ok(deletado);
        }
    }
}

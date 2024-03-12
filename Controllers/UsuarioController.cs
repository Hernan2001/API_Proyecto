using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Api_Piwapp.Models;
using Proyecto_Api_Piwapp.Repositories;

namespace Proyecto_Api_Piwapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioController(UsuarioRepository _usuarioRepository)
        {
            usuarioRepository = _usuarioRepository;
        }

        [HttpGet]
        public IActionResult GetUsuarios() //* get all
        {
            return Ok(usuarioRepository.GetAll());
        }

        [HttpPost]
        public IActionResult CreateUsuario(Usuario usuario) //* ADD añadir
        {
            Usuario newUsuario = usuarioRepository.Add(usuario);
            if (newUsuario == null)
            {
                return BadRequest();
            }
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuario(string id) //* GET x id
        {
            Usuario usuario = usuarioRepository.Get(new Usuario()
            {
                Id = id
            });

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPut]
        public IActionResult UpdateUsuario(Usuario usuario) //* actualizar x id
        {
            Usuario usuarioFromFirebase = usuarioRepository.Get(new Usuario()
            {
                Id = usuario.Id
            });

            if (usuarioFromFirebase == null)
                return NotFound();

            if (usuarioRepository.Update(usuario))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(string id) //* delete x id
        {
            if (usuarioRepository.Delete(new Usuario()
            {
                Id = id
            }))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

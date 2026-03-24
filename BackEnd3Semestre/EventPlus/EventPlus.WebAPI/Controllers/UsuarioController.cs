    using EventPlus.WebAPI.Interfaces;
    using EventPlus.WebAPI.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    namespace EventPlus.WebAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UsuarioController : ControllerBase
        {
            private readonly IUsuarioRepository _usuarioRepository;
            public UsuarioController(IUsuarioRepository usuarioRepository)
            {
                _usuarioRepository = usuarioRepository;
            }
            /// <summary>
            /// Endpoint da API que faz a chamada para metodo de um usuario por id
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            [HttpGet("{id}")]
            public IActionResult BuscarPorId(Guid Id)
            {
                try
                {
                    return Ok(_usuarioRepository.BuscarPorId(Id));        
                }
                catch (Exception error)
                {

                    return BadRequest(error.Message);
                }
            }
            [HttpPost]
            public IActionResult Cadastrar(Usuario usuario)
            {
                try
                {
                    _usuarioRepository.Cadastrar(usuario);
                    return StatusCode(201, usuario);
                }
                catch (Exception error)
                {

                    return BadRequest(error.Message);
                }
            }
        }
    }

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.API.Dtos;
using AmparoAmigo.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmparoAmigo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDto usuario)
        {
            try
            {
                var idVoluntario = await _usuarioService.Logar(usuario.Email, usuario.Senha);

                return Ok(idVoluntario);
            }
            catch (ValidationException vEx)
            {
                return BadRequest(vEx.Message);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Adicionar voluntario. Erro: {ex.Message}");
            }
        }
    }
}
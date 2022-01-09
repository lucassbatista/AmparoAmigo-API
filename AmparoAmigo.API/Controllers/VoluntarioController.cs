using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.API.Dtos;
using AmparoAmigo.Domain.Entities;
using AmparoAmigo.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmparoAmigo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoluntarioController : ControllerBase
    {
        private readonly IVoluntarioService _voluntarioService;

        public VoluntarioController(IVoluntarioService voluntarioService)
        {
            _voluntarioService = voluntarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var voluntarios = await _voluntarioService.PegarTodosVoluntariosAsync();
                if (voluntarios == null) return NoContent();

                return Ok(voluntarios);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar voluntarios. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var voluntario = await _voluntarioService.PegarVoluntarioPorIdAsync(id);
                if (voluntario == null) return NoContent();

                return Ok(voluntario);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar voluntario com id: ${id}. Erro: {ex.Message}");
            }
        }

        [HttpGet("{categoria}/{tipoServico}/{estado}/{cidade}")]
        public async Task<IActionResult> Get(string categoria, string tipoServico, string estado, string cidade)
        {
            try
            {
                var voluntarios = await _voluntarioService.PegarVoluntarioPorFiltro(categoria, tipoServico, estado, cidade);
                if (voluntarios == null) return NoContent();

                return Ok(voluntarios);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar voluntarios. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CadastroVoluntarioDto cadastroDto)
        {
            try
            {
                Voluntario voluntario = cadastroDto.ToModelVoluntario();
                Usuario usuario = cadastroDto.ToModelUsuario();

                var voluntarioInserido = await _voluntarioService.AdicionarVoluntario(voluntario, usuario);
                if (voluntarioInserido == null) return NoContent();

                return Ok(voluntarioInserido);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Voluntario model)
        {
            try
            {
                if (model.Id != id)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando atualizar a voluntario errado");

                var voluntario = await _voluntarioService.AtualizarVoluntario(model);
                if (voluntario == null) return NoContent();

                return Ok(voluntario);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Atualizar voluntario com id: ${id}. Erro: {ex.Message}");
            }
        }

        [HttpGet("categorias")]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var categorias = await _voluntarioService.PegarCategoriasVoluntarios();
                if (categorias == null) return NoContent();

                return Ok(categorias);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar as categorias dos voluntarios. Erro: {ex.Message}");
            }
        }

        [HttpGet("tiposServico/{categoria}")]
        public async Task<IActionResult> GetTiposServicos(string categoria)
        {
            try
            {
                var tiposServicos = await _voluntarioService.PegarTiposServicosVoluntarios(categoria);
                if (tiposServicos == null) return NoContent();

                return Ok(tiposServicos);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os tipos dos serviços dos voluntarios. Erro: {ex.Message}");
            }
        }

    }
}
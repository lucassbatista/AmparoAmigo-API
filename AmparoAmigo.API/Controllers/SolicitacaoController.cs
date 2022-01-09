using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.API.Dtos;
using AmparoAmigo.API.Extension;
using AmparoAmigo.Domain.Entities;
using AmparoAmigo.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmparoAmigo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoService _solicitacaoService;

        public SolicitacaoController(ISolicitacaoService solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;
        }
                
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var solicitacoes = await _solicitacaoService.PegarTodasSolicitacoesAsync();
                if (solicitacoes == null) return NoContent();

                return Ok(solicitacoes);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar solicitações. Erro: {ex.Message}");
            }
        }

        [HttpGet("{voluntarioId}")]
        public async Task<IActionResult> Get(int voluntarioId)
        {
            try
            {
                var solicitacoes = await _solicitacaoService.PegarSolicitacoesPorIdVoluntarioAsync(voluntarioId);
                if (solicitacoes == null) return NoContent();

                return Ok(solicitacoes);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar solicitações do voluntario com id: ${voluntarioId}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(SolicitacaoDto solicitacaoDto)
        {
            try
            {
                if(!solicitacaoDto.CNPJ.IsCnpj())
                    throw new ValidationException("CNPJ Inválido");

                var solicitacao = await _solicitacaoService.AdicionarSolicitacao(solicitacaoDto.ToModel());
                if (solicitacao == null) return NoContent();

                return Ok(solicitacao);
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
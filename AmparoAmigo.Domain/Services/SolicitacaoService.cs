using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Domain.Entities;
using AmparoAmigo.Domain.Interfaces.Repositories;
using AmparoAmigo.Domain.Interfaces.Services;

namespace AmparoAmigo.Domain.Services
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        private readonly IVoluntarioRepository _voluntarioRepository;

        public SolicitacaoService(ISolicitacaoRepository solicitacaoRepository, IVoluntarioRepository voluntarioRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
            _voluntarioRepository = voluntarioRepository;
        }

        public async Task<Solicitacao> AdicionarSolicitacao(Solicitacao model)
        {
            if (await _voluntarioRepository.PegaPorIdAsync(model.VoluntarioId) == null)
                throw new ValidationException("Não existe o voluntario associado a essa solicitação");

            _solicitacaoRepository.Adicionar(model);
            if(await _solicitacaoRepository.SalvarMudancasAsync())
                return model;

            return null;
        }

        public async Task<Solicitacao[]> PegarSolicitacoesPorIdVoluntarioAsync(int voluntarioId)
        {
            try
            {
                var solicitacoes = await _solicitacaoRepository.PegaPorIdVoluntarioAsync(voluntarioId);
                if (solicitacoes == null) return null;

                return solicitacoes;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Solicitacao[]> PegarTodasSolicitacoesAsync()
        {
            try
            {
                var solicitacoes = await _solicitacaoRepository.PegaTodosAsync();
                if (solicitacoes == null) return null;

                return solicitacoes;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
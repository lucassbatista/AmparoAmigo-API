using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Domain.Entities;

namespace AmparoAmigo.Domain.Interfaces.Services
{
    public interface ISolicitacaoService
    {
        Task<Solicitacao> AdicionarSolicitacao(Solicitacao model);

        Task<Solicitacao[]> PegarTodasSolicitacoesAsync();
        
        Task<Solicitacao[]> PegarSolicitacoesPorIdVoluntarioAsync(int voluntarioId);
    }
}
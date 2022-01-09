using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Data.Context;
using AmparoAmigo.Domain.Entities;
using AmparoAmigo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AmparoAmigo.Data.Repositories
{
    public class SolicitacaoRepository : GenericRepository, ISolicitacaoRepository
    {
        private readonly DataContext _context;
        public SolicitacaoRepository(DataContext context): base(context)
        {
            _context = context;
        }
        
        public async Task<Solicitacao[]> PegaPorIdVoluntarioAsync(int voluntarioId)
        {
            IQueryable<Solicitacao> query = _context.Solicitacoes;

            query = query.AsNoTracking()
                         .OrderByDescending(solicitacao => solicitacao.DataCriacao)
                         .Where(solicitacao => solicitacao.VoluntarioId == voluntarioId);

            return await query.ToArrayAsync();
        }

        public async Task<Solicitacao[]> PegaTodosAsync()
        {
            IQueryable<Solicitacao> query = _context.Solicitacoes;

            query = query.AsNoTracking()
                         .OrderByDescending(solicitacao => solicitacao.DataCriacao);

            return await query.ToArrayAsync();
        }
    }
}
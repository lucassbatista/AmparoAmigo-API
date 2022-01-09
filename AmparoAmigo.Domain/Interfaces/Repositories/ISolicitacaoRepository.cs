using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Domain.Entities;

namespace AmparoAmigo.Domain.Interfaces.Repositories
{
    public interface ISolicitacaoRepository : IGenericRepository
    {

        Task<Solicitacao[]> PegaTodosAsync();
        Task<Solicitacao[]> PegaPorIdVoluntarioAsync(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Domain.Entities;

namespace AmparoAmigo.Domain.Interfaces.Repositories
{
    public interface IVoluntarioRepository : IGenericRepository
    {
        Task<Voluntario[]> PegaTodosAsync();

        Task<Voluntario> PegaPorIdAsync(int id);

        Task<Voluntario[]> PegaPorFiltroAsync(string categoria, string tipoServico, string estado, string cidade);

    }
}
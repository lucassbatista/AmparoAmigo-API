using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Data.Context;
using AmparoAmigo.Domain.Entities;
using AmparoAmigo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AmparoAmigo.Data.Repositories
{
    public class VoluntarioRepository : GenericRepository, IVoluntarioRepository
    {
        private readonly DataContext _context;
        public VoluntarioRepository(DataContext context): base(context)
        {
            _context = context;
        }

        public async Task<Voluntario> PegaPorIdAsync(int id)
        {
            IQueryable<Voluntario> query = _context.Voluntarios;

            query = query.AsNoTracking()
                         .OrderBy(voluntario => voluntario.Id)
                         .Where(voluntario => voluntario.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Voluntario[]> PegaTodosAsync()
        {
            IQueryable<Voluntario> query = _context.Voluntarios;

            query = query.AsNoTracking()
                         .OrderBy(voluntario => voluntario.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Voluntario[]>  PegaPorFiltroAsync(string categoria, string tipoServico, string estado, string cidade)
        {
            IQueryable<Voluntario> query = _context.Voluntarios;

            query = query.AsNoTracking()
                         .OrderBy(voluntario => voluntario.Id);

            if(categoria.Length > 1)
                query = query.Where(v => v.Categoria1.Equals(categoria) ||
                                         v.Categoria2.Equals(categoria) ||
                                         v.Categoria3.Equals(categoria));

            if(tipoServico.Length > 1)
                query = query.Where(v => v.TipoServico1.Equals(tipoServico) ||
                                         v.TipoServico2.Equals(tipoServico) ||
                                         v.TipoServico3.Equals(tipoServico));

            if(estado.Length > 1)
                query = query.Where(v => v.Estado.Equals(estado));

            if(cidade.Length > 1)
                query = query.Where(v => v.Cidade.Trim().Equals(cidade.Trim()));

            return await query.ToArrayAsync();
        }
    }
}
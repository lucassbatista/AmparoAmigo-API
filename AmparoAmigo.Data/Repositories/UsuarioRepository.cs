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
    public class UsuarioRepository : GenericRepository, IUsuarioRepository
    {

        private readonly DataContext _context;
        public UsuarioRepository(DataContext context): base(context)
        {
            _context = context;
        }

        public async Task<Usuario> PegaPorEmailAsync(string email)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario.Id)
                         .Where(usuario => usuario.Email.ToUpper().Equals(email.ToUpper()));

            return await query.FirstOrDefaultAsync();
        }
    }
}
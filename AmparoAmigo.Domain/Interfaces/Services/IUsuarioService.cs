using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Domain.Entities;

namespace AmparoAmigo.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<int> Logar(string email, string senha);
    }
}
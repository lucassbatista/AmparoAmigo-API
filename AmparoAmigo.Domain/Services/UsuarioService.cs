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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<int> Logar(string email, string senha)
        {
            Usuario usuario= await _usuarioRepository.PegaPorEmailAsync(email);

            if(usuario == null || !usuario.Senha.Equals(senha))
                throw new ValidationException("Usuario ou senha estão incorretos");

            return usuario.VoluntarioId;
        }
    }
}
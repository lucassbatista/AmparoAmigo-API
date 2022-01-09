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
    public class VoluntarioService : IVoluntarioService
    {
        private readonly IVoluntarioRepository _voluntarioRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public VoluntarioService(IVoluntarioRepository voluntarioRepository, IUsuarioRepository usuarioRepository)
        {
            _voluntarioRepository = voluntarioRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Voluntario> AdicionarVoluntario(Voluntario voluntario, Usuario usuario)
        {
            if (await _usuarioRepository.PegaPorEmailAsync(usuario.Email) != null)
                throw new ValidationException("Já existe uma voluntário com esse Email");

            if (await _voluntarioRepository.PegaPorIdAsync(voluntario.Id) == null)
            {
                _voluntarioRepository.Adicionar(voluntario);
                
                if (await _voluntarioRepository.SalvarMudancasAsync())
                {                
                    usuario.VoluntarioId = voluntario.Id;
                    _usuarioRepository.Adicionar(usuario);
                    if(await _usuarioRepository.SalvarMudancasAsync())
                        return voluntario;
                }
            }

            return null;
        }

        public async Task<Voluntario> AtualizarVoluntario(Voluntario model)
        {
            if (await _voluntarioRepository.PegaPorIdAsync(model.Id) != null)
            {
                _voluntarioRepository.Atualizar(model);
                if (await _voluntarioRepository.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<Voluntario[]> PegarTodosVoluntariosAsync()
        {
            try
            {
                var voluntarios = await _voluntarioRepository.PegaTodosAsync();
                if (voluntarios == null) return null;

                return voluntarios;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Voluntario> PegarVoluntarioPorIdAsync(int voluntarioId)
        {
            try
            {
                var voluntario = await _voluntarioRepository.PegaPorIdAsync(voluntarioId);
                if (voluntario == null) return null;

                return voluntario;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Voluntario[]> PegarVoluntarioPorFiltro(string categoria, string tipoServico, string estado, string cidade)
        {
            try
            {
                var voluntarios = await _voluntarioRepository.PegaPorFiltroAsync(categoria, tipoServico, estado, cidade);
                if (voluntarios == null) return null;

                return voluntarios;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<string>> PegarCategoriasVoluntarios()
        {
                List<string> categorias = new List<string>();
                var voluntarios = await _voluntarioRepository.PegaTodosAsync();
                if (voluntarios == null) return null;
                
                voluntarios.ToList().ForEach(v => 
                {
                    if(!string.IsNullOrEmpty(v.Categoria1)) categorias.Add(v.Categoria1);
                    if(!string.IsNullOrEmpty(v.Categoria2)) categorias.Add(v.Categoria2);
                    if(!string.IsNullOrEmpty(v.Categoria3)) categorias.Add(v.Categoria3);
                });

                return categorias;
        }

        public async Task<List<string>> PegarTiposServicosVoluntarios(string categoria)
        {
                List<string> servicos = new List<string>();

                var voluntarios = await _voluntarioRepository.PegaTodosAsync();
                if (voluntarios == null) return null;
                
                voluntarios.Where(v => (!string.IsNullOrEmpty(v.Categoria1) && v.Categoria1.ToUpper().Equals(categoria.ToUpper())) ||
                                       (!string.IsNullOrEmpty(v.Categoria2) &&v.Categoria2.ToUpper().Equals(categoria.ToUpper())) ||
                                       (!string.IsNullOrEmpty(v.Categoria3) &&v.Categoria3.ToUpper().Equals(categoria.ToUpper())))
                .ToList().ForEach(v => 
                {
                    if(!string.IsNullOrEmpty(v.TipoServico1)) servicos.Add(v.TipoServico1);
                    if(!string.IsNullOrEmpty(v.TipoServico2)) servicos.Add(v.TipoServico2);
                    if(!string.IsNullOrEmpty(v.TipoServico3)) servicos.Add(v.TipoServico3);
                });

                return servicos;
        }

        public async Task<List<string>> PegarEstadosVoluntarios()
        {
            List<string> estados = new List<string>();
            var voluntarios = await _voluntarioRepository.PegaTodosAsync();
            if (voluntarios == null) return null;
               
            voluntarios.ToList().ForEach(v => estados.Add(v.Estado));
            
            return estados;
        }

        public async Task<List<string>> PegarCidadesVoluntarios(string estado)
        {
            List<string> cidades = new List<string>();
            var voluntarios = await _voluntarioRepository.PegaTodosAsync();
            if (voluntarios == null) return null;
               
            voluntarios.Where(v => v.Estado.ToUpper().Equals(estado.ToUpper())).ToList().ForEach(v => cidades.Add(v.Cidade));
            
            return cidades;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Domain.Entities;

namespace AmparoAmigo.Domain.Interfaces.Services
{
    public interface IVoluntarioService
    {
        Task<Voluntario> AdicionarVoluntario(Voluntario model, Usuario usuario);
        Task<Voluntario> AtualizarVoluntario(Voluntario model);
        Task<Voluntario[]> PegarTodosVoluntariosAsync();
        Task<Voluntario> PegarVoluntarioPorIdAsync(int voluntarioId);
        Task<Voluntario[]> PegarVoluntarioPorFiltro(string categoria, string tipoServico, string estado, string cidade);

        Task<List<string>> PegarCategoriasVoluntarios();
        Task<List<string>> PegarTiposServicosVoluntarios(string categoria);
        Task<List<string>> PegarEstadosVoluntarios();
        Task<List<string>> PegarCidadesVoluntarios(string estado);
    }
}
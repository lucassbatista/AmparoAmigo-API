using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Domain.Entities;

namespace AmparoAmigo.API.Dtos
{
    public class CadastroVoluntarioDto
    {
        public string NomeCompleto { get; set; }    
        public DateTime DataNascimento { get; set; }
        public string TelefoneCelular { get; set; } 
        public string Endereco { get; set; }    
        public string Cidade { get; set; }    
        public string Estado { get; set; }
        public string TipoServico1 { get; set; }
        public string TipoServico2 { get; set; }
        public string TipoServico3 { get; set; }
        public string Descricao { get; set; }
        public string Categoria1 { get; set; }
        public string Categoria2 { get; set; }
        public string Categoria3 { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }

    }

    public static class CadastroVoluntarioDtoMapper
    {
        public static Voluntario ToModelVoluntario(this CadastroVoluntarioDto dto)
        {
            Voluntario voluntario = new Voluntario();
            voluntario.NomeCompleto = dto.NomeCompleto;
            voluntario.DataNascimento = dto.DataNascimento;
            voluntario.TelefoneCelular = dto.TelefoneCelular;
            voluntario.Endereco = dto.Endereco;
            voluntario.Cidade = dto.Cidade;
            voluntario.Estado = dto.Estado;
            voluntario.TipoServico1 = dto.TipoServico1;
            voluntario.TipoServico2 = dto.TipoServico2;
            voluntario.TipoServico3 = dto.TipoServico3;
            voluntario.Descricao = dto.Descricao;
            voluntario.Categoria1 = dto.Categoria1;
            voluntario.Categoria2 = dto.Categoria2;
            voluntario.Categoria3 = dto.Categoria3;

            return voluntario;
        }

        public static Usuario ToModelUsuario(this CadastroVoluntarioDto dto)
        {
            Usuario usuario = new Usuario();
            usuario.Email = dto.Email;
            usuario.Senha = dto.Senha;

            return usuario;
        }
    }
}
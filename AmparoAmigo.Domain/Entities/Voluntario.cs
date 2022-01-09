using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmparoAmigo.Domain.Entities
{
    public class Voluntario
    {
        public Voluntario() { }

        public Voluntario(int id, string nomecompleto, DateTime dataNascimento, string telefoneCelular, string endereco, string cidade, string estado, string tipoServico1, string descricao, string categoria1) 
        {
            this.Id = id;
            this.NomeCompleto = nomecompleto;
            this.DataNascimento = dataNascimento;
            this.TelefoneCelular = telefoneCelular;
            this.Endereco = endereco;
            this.Cidade = cidade;
            this.Estado = estado;
            this.TipoServico1 = tipoServico1;
            this.Descricao = descricao;
            this.Categoria1 = categoria1;
        }

        public int Id { get; set; } 
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
    }
}
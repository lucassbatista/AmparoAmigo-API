using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmparoAmigo.Domain.Entities
{
    public class Solicitacao
    {
        public Solicitacao()
        {
            this.DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string TelefoneCelular { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Responsavel { get; set; }
        public DateTime DataCriacao { get; set; }
        
        public int VoluntarioId { get; set; }
        public Voluntario Voluntario { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Domain.Entities;

namespace AmparoAmigo.API.Dtos
{
    public class SolicitacaoDto
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string TelefoneCelular { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Responsavel { get; set; }
        public int VoluntarioId { get; set; }
    }

    public static class SolicitacaoDtoDtoMapper
    {
        public static Solicitacao ToModel(this SolicitacaoDto dto)
        {
            Solicitacao solicitacao = new Solicitacao();
            solicitacao.RazaoSocial = dto.RazaoSocial;
            solicitacao.CNPJ = dto.CNPJ;
            solicitacao.TelefoneCelular = dto.TelefoneCelular;
            solicitacao.Endereco = dto.Endereco;
            solicitacao.Estado = dto.Estado;
            solicitacao.Cidade = dto.Cidade;
            solicitacao.Responsavel = dto.Responsavel;
            solicitacao.VoluntarioId = dto.VoluntarioId;
            solicitacao.DataCriacao = DateTime.Now;

            return solicitacao;
        }
    }
}
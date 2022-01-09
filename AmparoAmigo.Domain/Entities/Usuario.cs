using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmparoAmigo.Domain.Entities
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(int id, string email, string senha, int voluntarioId)
        {
            this.Id = id;
            this.Email = email;
            this.Senha = senha;
            this.VoluntarioId = voluntarioId;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public int VoluntarioId { get; set; }
        public Voluntario Voluntario { get; set; }
    }
}
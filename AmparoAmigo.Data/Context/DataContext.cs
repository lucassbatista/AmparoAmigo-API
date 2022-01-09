using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmparoAmigo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmparoAmigo.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Voluntario>()
                   .HasKey(v => new {v.Id});

            builder.Entity<Usuario>()
                   .HasKey(u => new {u.Id});

            builder.Entity<Solicitacao>()
                   .HasKey(s => new {s.Id});

            builder.Entity<Voluntario>()
                   .HasData(new List<Voluntario>()
                   {
                       new Voluntario(1, "Lucas Batista", new DateTime(1996,11,04),"(11) 98763-6567", "Rua 1", "São Paulo", "SP", "Professor", "Leciono a 10 anos", "Educação"),
                       new Voluntario(2, "Leonardo Lopes", new DateTime(1998,09,30),"(11) 98763-6567", "Rua 2", "Rio de Janeiro", "RJ", "Ajudante Geral", "Quero Ajudar", "Geral"),
                       new Voluntario(3, "Diego Grava", new DateTime(1986,08,15),"(11) 98763-6567", "Rua 3", "Governador Valadares", "MG", "Professor Artes", "Leciono a 10 anos", "Comunicação"),
                       new Voluntario(4, "Igor Kimura", new DateTime(1998,06,08),"(11) 98763-6567", "Rua 4", "Acrelândia", "AC", "Rapper", "ensino musica", "serviços Gerais"),
                       new Voluntario(5, "Fabricio Antunes", new DateTime(1976,9,22),"(11) 98763-6567", "Rua 5", "Florianópolis", "SC", "Enfermeiro", "Sou Enfermeiro a 10 anos", "Saúde")
                   });

            builder.Entity<Usuario>()
                   .HasData(new List<Usuario>()
                   {
                       new Usuario(1, "LucasBatista@gmail.com", "Teste123", 1),
                       new Usuario(2, "LeonardoLopez@gmail.com", "Teste123", 2),
                       new Usuario(3, "DiegoGrava@gmail.com", "Teste123", 3),
                       new Usuario(4, "IgorKimura@gmail.com", "Teste123", 4),
                       new Usuario(5, "FabricioAntunes@gmail.com", "Teste123", 5),
                   });
            
        }
    }
}
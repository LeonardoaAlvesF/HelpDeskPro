using Microsoft.EntityFrameworkCore;
using HelpDeskPro.API.Models;
namespace HelpDeskPro.API.Data;

    public class AppDbContext : DbContext // Contexto do banco de dados
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) //Criação do banco
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } // Criação das tabelas
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento: Usuario (criador) -> Chamado
            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Usuario) // Um Usuário pode ter vários chamados
                .WithMany(u => u.Chamados)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); // Impede apagar usuarios e chamados em cascata

            // Relacionamento: Tecnico -> Chamado
            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Tecnico) //Um técnico pode atender vários chamados
                .WithMany()
                .HasForeignKey(c => c.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }

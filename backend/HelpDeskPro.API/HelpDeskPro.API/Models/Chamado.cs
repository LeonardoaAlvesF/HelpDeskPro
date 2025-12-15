using System.ComponentModel.DataAnnotations;

namespace HelpDeskPro.API.Models
{
    public class Chamado
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        public StatusChamado Status { get; set; } = StatusChamado.Aberto;

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataEncerramento { get; set; }

        // Relacionamentos
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int? TecnicoId { get; set; }
        public Usuario Tecnico { get; set; }

        public ICollection<Comentario> Comentarios { get; set; } // Relacionamento 1:N com Comentarios
    }
}

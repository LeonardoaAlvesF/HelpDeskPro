using System.ComponentModel.DataAnnotations;

namespace HelpDeskPro.API.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public int ChamadoId { get; set; }
        public Chamado Chamado { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}

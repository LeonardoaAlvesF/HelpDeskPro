using System.ComponentModel.DataAnnotations;

namespace HelpDeskPro.API.DTOs
{
    public class ComentarioCreateDto
    {
        [Required]
        public string Texto { get; set; }

        [Required]
        public int ChamadoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}

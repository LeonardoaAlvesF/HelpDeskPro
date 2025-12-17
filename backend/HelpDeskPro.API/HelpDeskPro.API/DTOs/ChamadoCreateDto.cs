using System.ComponentModel.DataAnnotations;

namespace HelpDeskPro.API.DTOs
{
    public class ChamadoCreateDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int TecnicoId { get; set; }
    }
}

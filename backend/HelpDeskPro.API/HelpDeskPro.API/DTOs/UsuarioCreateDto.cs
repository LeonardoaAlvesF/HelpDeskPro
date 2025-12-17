using HelpDeskPro.API.Models;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskPro.API.DTOs
{
    public class UsuarioCreateDto
    {
        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }
    }
}

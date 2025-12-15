using System.ComponentModel.DataAnnotations;
using HelpDeskPro.API.Models;

namespace HelpDeskPro.API.DTOs
{
    public class UsuarioCreateDto
    {
        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Senha { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }
    }
}

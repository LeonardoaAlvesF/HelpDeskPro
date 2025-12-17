using HelpDeskPro.API.Models;

namespace HelpDeskPro.API.DTOs
{
    public class UsuarioReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuario Tipo { get; set; }
    }
}

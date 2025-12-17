using HelpDeskPro.API.Models;

namespace HelpDeskPro.API.DTOs
{
    public class ChamadoReadDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusChamado Status { get; set; }
        public DateTime DataCriacao { get; set; }

        public int UsuarioId { get; set; }
        public int TecnicoId { get; set; }
    }
}

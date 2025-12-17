namespace HelpDeskPro.API.DTOs
{
    public class ComentarioReadDto
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }

        public int ChamadoId { get; set; }
        public int UsuarioId { get; set; }
    }
}

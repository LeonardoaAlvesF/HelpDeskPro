using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HelpDeskPro.API.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public int ChamadoId { get; set; }
        [JsonIgnore]
        public Chamado? Chamado { get; set; }

        public int UsuarioId { get; set; }
        
        [JsonIgnore]
        public Usuario? Usuario { get; set; }

    }
}

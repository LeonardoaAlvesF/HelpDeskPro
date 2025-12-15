using HelpDeskPro.API.Models;
using System.Text.Json.Serialization;

public class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string SenhaHash { get; set; }

    public TipoUsuario Tipo { get; set; }

    public DateTime DataCriacao { get; set; }

    [JsonIgnore]
    public ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();

    [JsonIgnore]
    public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
}

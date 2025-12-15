using HelpDeskPro.API.Models;
using System.Text.Json.Serialization;

public class Chamado
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Descricao { get; set; }

    public StatusChamado Status { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime? DataEncerramento { get; set; }

    public int UsuarioId { get; set; }

    public int? TecnicoId { get; set; }

    [JsonIgnore]
    public Usuario? Usuario { get; set; }

    [JsonIgnore]
    public Usuario? Tecnico { get; set; }

    [JsonIgnore]
    public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
}

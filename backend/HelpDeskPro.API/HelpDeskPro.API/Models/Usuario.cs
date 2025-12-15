using System.ComponentModel.DataAnnotations;

namespace HelpDeskPro.API.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string SenhaHash { get; set; }

    [Required]
    public TipoUsuario Tipo { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public ICollection<Chamado> Chamados { get; set; }
    public ICollection<Comentario> Comentarios { get; set; }
}

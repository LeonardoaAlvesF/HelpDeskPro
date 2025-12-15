using HelpDeskPro.API.Data;
using HelpDeskPro.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComentariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/comentarios/chamado/5
        [HttpGet("chamado/{chamadoId}")]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentariosPorChamado(int chamadoId)
        {
            return await _context.Comentarios
                .Where(c => c.ChamadoId == chamadoId)
                .ToListAsync();
        }

        // POST: api/comentarios
        [HttpPost]
        public async Task<ActionResult<Comentario>> PostComentario(Comentario comentario)
        {
            comentario.DataCriacao = DateTime.Now;

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return Ok(comentario);
        }
    }
}

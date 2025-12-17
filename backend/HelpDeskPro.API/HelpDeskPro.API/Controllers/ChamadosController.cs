using HelpDeskPro.API.Data;
using HelpDeskPro.API.DTOs;
using HelpDeskPro.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskPro.API.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ChamadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChamadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/chamados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoReadDto>>> GetChamados()
        {
            return await _context.Chamados
                .Select(c => new ChamadoReadDto
                {
                    Id = c.Id,
                    Titulo = c.Titulo,
                    Descricao = c.Descricao,
                    Status = c.Status,
                    DataCriacao = c.DataCriacao,
                    UsuarioId = c.UsuarioId,
                    TecnicoId = c.TecnicoId
                })
                .ToListAsync();
        }


        // GET: api/chamados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chamado>> GetChamado(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);

            if (chamado == null)
                return NotFound();

            return chamado;
        }

        // POST: api/chamados
        [HttpPost]
        public async Task<ActionResult<ChamadoReadDto>> PostChamado(ChamadoCreateDto dto)
        {
            var chamado = new Chamado
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                UsuarioId = dto.UsuarioId,
                TecnicoId = dto.TecnicoId,
                Status = StatusChamado.Aberto,
                DataCriacao = DateTime.Now
            };

            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();

            var readDto = new ChamadoReadDto
            {
                Id = chamado.Id,
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                Status = chamado.Status,
                DataCriacao = chamado.DataCriacao,
                UsuarioId = chamado.UsuarioId,
                TecnicoId = chamado.TecnicoId
            };

            return CreatedAtAction(nameof(GetChamado), new { id = chamado.Id }, readDto);
        }


        // PUT: api/chamados/5/atribuir
        [HttpPut("{id}/atribuir")]
        public async Task<IActionResult> AtribuirTecnico(int id, int tecnicoId)
        {
            var chamado = await _context.Chamados.FindAsync(id);

            if (chamado == null)
                return NotFound();

            chamado.TecnicoId = tecnicoId;
            chamado.Status = StatusChamado.EmAndamento;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/chamados/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> AlterarStatus(int id, StatusChamado status)
        {
            var chamado = await _context.Chamados.FindAsync(id);

            if (chamado == null)
                return NotFound();

            chamado.Status = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/chamados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChamado(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);

            if (chamado == null)
                return NotFound();

            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

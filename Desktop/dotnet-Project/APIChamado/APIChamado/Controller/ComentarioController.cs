using APIChamado.Context;
using APIChamado.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APIChamado.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ComentarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comentario>> GetAllComentario()
        {
            var comentario = _context.Comentario.ToList();
            if(comentario is null)
            {
                return NotFound("Não há comentarios");
            }
            return comentario;
        }

        [HttpGet("{id:int}", Name = "GetComentarioId")]
        public ActionResult<Comentario> GetComentario(int id)
        {
            var comentario = _context.Comentario.FirstOrDefault(p => p.ChamadoId == id);
            if(comentario is null)
            {
                return NotFound("Comentario não Encontrado");
            }
            return comentario;
        }

        [HttpPost]
        public ActionResult PostComentario(Comentario comentario)
        {
            if(comentario is null)
            {
                return BadRequest("Insira Valores Válidos para o Comentario");
            }
            _context.Comentario.Add(comentario);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetComentarioId", new
            {
                id = comentario.ComentarioId,
            }, comentario);
        }

        [HttpPut("{id:int}")]
        public ActionResult PutComentario(int id, Comentario comentario)
        {

            if(comentario is null)
            {
                return BadRequest("Insira Valores Validos Para a alteração do Comentario");
            }
            if(comentario.ComentarioId != id)
            {
                return BadRequest("Verifique o id informado");
            }
            _context.Entry(comentario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(comentario);
        }

        
        [HttpDelete]
        public ActionResult DeleteComentario(int id)
        {
            var comentario =  _context.Comentario.FirstOrDefault(p => p.ComentarioId == id);
            if(comentario is null)
            {
                return BadRequest("Comenrario não Encontrado");
            }
            _context.Remove(comentario);
            _context.SaveChanges();
            return Ok(comentario);
        } 
    }
}

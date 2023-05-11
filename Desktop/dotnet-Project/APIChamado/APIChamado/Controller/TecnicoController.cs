using APIChamado.Context;
using APIChamado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIChamado.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TecnicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tecnico>> GetTecnicos()
        {
            var tecnicos = _context.Tecnicos.ToList();
            if(tecnicos is null)
            {
                return NotFound("Técnicos não encontrado");
            }
            return tecnicos;
            
        }

        [HttpGet("{id:int}", Name = "GetId")]
        public ActionResult<Tecnico> GetId(int id)
        {
            var tecnico = _context.Tecnicos.FirstOrDefault(p => p.TecnicoId == id);
            if(tecnico is null)
            {
                return NotFound("Tecnico não encontrado");
            }
            return tecnico;
        }

        [HttpPost]
        public ActionResult Post(Tecnico tecnico)
        {
            if(tecnico is null)
            {
                return BadRequest();
            }

            _context.Tecnicos.Add(tecnico); // adicionando o meu tecnico na memoria local
            _context.SaveChanges(); // adicionando o tecnico da memoria local no banco de dados

            return new CreatedAtRouteResult("GetId",
                new { id = tecnico.TecnicoId }, tecnico);

        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Tecnico tecnico)
        {
            if(id != tecnico.TecnicoId)
            {
                return BadRequest();
            }
            _context.Entry(tecnico).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(tecnico);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var tecnico = _context.Tecnicos.FirstOrDefault(p=> p.TecnicoId == id);
            if(tecnico is null)
            {
                return NotFound("Tecnico não encontrado");
            }
            _context.Tecnicos.Remove(tecnico);
            _context.SaveChanges();

            return Ok(tecnico);
        }
    }
}

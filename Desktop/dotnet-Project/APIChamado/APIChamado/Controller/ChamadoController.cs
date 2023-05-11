using APIChamado.Context;
using APIChamado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIChamado.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ChamadoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Chamado>> GetChamados()
        {
            var chamados =  _context.Chamados.ToList();
           if(chamados is null)
            {
                return NotFound("Não Possui Chamados na lista");
            }
            return chamados;
        }

        [HttpGet("{id:int}", Name = "GetIdChamado")]
        public ActionResult<Chamado> GetChamadoId(int id)
        {
            var chamado = _context.Chamados.FirstOrDefault(p => p.ChamadoId == id);
            if (chamado is null)
            {
                return NotFound("Chamado não encontrado");
            }
            return chamado;
        }

        [HttpPost]
        public ActionResult PostChamado(Chamado chamado)
        {
            if (chamado is null)
            {
                return BadRequest("Insira os Dados para a Abertura do Chamado");
            }
            _context.Chamados.Add(chamado);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetIdChamado", new { id = chamado.ChamadoId }, chamado);
        }

        [HttpPut("{id:int}")]
        public ActionResult PutChamado(int id,Chamado chamado)
        {
            if(chamado is null)
            {
                return BadRequest("Insira Valores Validos para a Alteração do Chamado");
            }
            if(chamado.ChamadoId == id)
            {
                return BadRequest("Verifique o Id do Chamado Informado");
            }
            _context.Entry(chamado).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(chamado);
            
        }

        [HttpDelete]
        public ActionResult DeleteChamado(int id)
        {
            var chamado = _context.Chamados.FirstOrDefault(p => p.ChamadoId == id);
            if(chamado is null)
            {
                return NotFound("Chamado não encontrado");
            }
            _context.Remove(chamado);
            _context.SaveChanges();
            return Ok(chamado); 
        }
    }
}

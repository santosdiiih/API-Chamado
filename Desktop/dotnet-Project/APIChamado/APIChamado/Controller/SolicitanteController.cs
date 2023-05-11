using APIChamado.Context;
using APIChamado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIChamado.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class SolicitanteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SolicitanteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Solicitante>> GetAllSolicitante()
        {
            var solicitantes = _context.Solicitante.ToList();
            if(solicitantes is null)
            {
                return BadRequest("Não foi Encontrado Solicitantes Cadastrado");
            }
            return solicitantes;
        }

        [HttpGet("{id:int}", Name = "GetSolicitanteId")]
        public ActionResult<Solicitante> GetSolicitanteId(int id)
        {
            var solicitante = _context.Solicitante.FirstOrDefault(p => p.SolicitanteId == id);
            if(solicitante is null)
            {
                return BadRequest("Solicitante não Encontrado");
            }
            return solicitante;
        }

        [HttpPost]
        public ActionResult PostSolicitante(Solicitante solicitante)
        {
            if(solicitante is null)
            {
                return BadRequest("Insira Valores Válidos para Criar o Perfil");
            }
            _context.Solicitante.Add(solicitante);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetSolicitanteId", new { id = solicitante.SolicitanteId }, solicitante);
        }

        [HttpPut("{id:int}")]
        public ActionResult PostSolicitante(Solicitante solicitante, int id)
        {
            if(solicitante is null)
            {
                return BadRequest("Adicione um Objeto Solicitante Valido");
            }
            if(solicitante.SolicitanteId != id)
            {
                return BadRequest("Verifique o id do Solicitante");
            }
            _context.Entry(solicitante).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(solicitante);
        }

        [HttpDelete]
        public ActionResult DeleteSolicitante(int id)
        {
            var solicitante = _context.Solicitante.FirstOrDefault(p => p.SolicitanteId == id);
            if(solicitante is null)
            {
                return NotFound("Solicitante não encontrado");
            }
            _context.Remove(solicitante);
            _context.SaveChanges();
            return Ok(solicitante); 
        }
    }
}

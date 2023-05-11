using APIChamado.Models;
using Microsoft.EntityFrameworkCore;

namespace APIChamado.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }
        public DbSet<Chamado> Chamados { get; set; }    
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Solicitante> Solicitante { get; set; }
    }
}

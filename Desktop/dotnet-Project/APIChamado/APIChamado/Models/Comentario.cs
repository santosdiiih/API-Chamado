using System.ComponentModel.DataAnnotations;

namespace APIChamado.Models
{
    public class Comentario
    {

        public int ComentarioId { get; set; }

        [MaxLength(250)]
        public string? ComentarioComent { get; set; }
        public DateTime ComentarioDate { get; set; }

        public int ChamadoId { get; set; }
        public Chamado? Chamado { get; set; }
        

    }
}

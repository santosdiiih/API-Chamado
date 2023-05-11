using System.ComponentModel.DataAnnotations;

namespace APIChamado.Models;

public class Chamado
{
    public int ChamadoId { get; set; }

    [Required(ErrorMessage = "O titulo do Chamado Deve ser Obrigatório")]
    public string? ChamadoTitle { get; set; }

    public string? ChamadoNumber { get; set; }

    [Required(ErrorMessage = "O Descritivo do Chamado Deve ser Obrigatório")]
    public string ChamadoDescription { get; set; }

    public string? ChamadoImage { get; set; }

    public DateTime ChamadoOpenDate { get; set; }

    public DateTime ChamadoClosingDate { get; set; }

    public DateTime ChamadoUpdateDate { get; set; }

    public int SolicitanteId { get; set; }  

    public int TecnicoId { get; set; }
    public ICollection<Comentario>? Comentarios { get; set; }

    public Solicitante Solicitante { get; set;}

    public Tecnico Tecnico { get; set; }

}

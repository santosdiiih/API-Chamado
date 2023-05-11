using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIChamado.Models;

public class Tecnico {

    public Tecnico()
    {
        Chamados = new Collection<Chamado>();
    }

    public int TecnicoId { get; set; }

    [MaxLength(150),Required(ErrorMessage = "O Nome do Técnico deve ser Obrigatório")]
    public string? TecnicoName { get; set; }

    [MaxLength(50),Required(ErrorMessage = "O Email do Técnico deve ser Obrigatório")]
    public  string? TecnicoEmail { get; set; }

    [MaxLength(20), Required(ErrorMessage = "A Senha do Técnico deve ser Obrigatório")]
    public string? TecnicoPassWord { get; set; } 

    public DateTime TecnicoDate { get; set; }

    public string? TecnicoOffice { get; set; }

    public string? TecnicoManager { get; set; }

    public string? TecnicoContact { get; set; } 

    public bool TecnicoStatus { get; set; } 

    public ICollection<Chamado>? Chamados { get; set; } 
}

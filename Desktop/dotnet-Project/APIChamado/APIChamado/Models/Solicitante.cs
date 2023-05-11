using System.ComponentModel.DataAnnotations;

namespace APIChamado.Models
{
    public class Solicitante
    {
        public int SolicitanteId { get; set; }
        
        [MaxLength(150), Required(ErrorMessage = "O Nome do Solicitante deve ser Obrigatório")]
        public string? SolicitanteName { get; set; }

        [MaxLength(50), Required(ErrorMessage = "O Email do Solicitante deve ser Obrigatório")]
        public string? SolicitanteEmail { get; set; }

        [MaxLength(20), Required(ErrorMessage = "A Senha do Solicitante deve ser Obrigatório")]
        public string? SolicitantePassWord { get; set; }

        public DateTime SolicitanteDate { get; set; }

        public string? SolicitanteOffice { get; set; }

        public string? SolicitanteManager { get; set; }

        public string? SolicitanteContact { get; set; }

        public bool SolicitanteStatus { get; set; }

        public ICollection<Chamado>? Chamados { get; set; } 
    }
}

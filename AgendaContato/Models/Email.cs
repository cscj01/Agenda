using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaContato.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "Preencha com um E-mail válido")]
        public string EnderecoEmail { get; set; }

        public TipoEmail Tipo { get; set; }
    }
}
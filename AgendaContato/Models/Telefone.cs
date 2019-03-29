using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaContato.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("DDD")]
        public int Ddd { get; set; }

        [DisplayName("Número")]
        public string Numero { get; set; }

        public TipoTelefone Tipo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaContato.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(2, ErrorMessage = "Minímo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(2, ErrorMessage = "Minímo 2 caracteres")]
        public string Sobrenome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        public virtual List<Telefone> Telefones { get; set; }
        public virtual List<Email> Emails { get; set; }
    }
}
using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UnidadeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome da unidade")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o status da unidade")]
        public StatusEnum Status { get; set; }

        public virtual List<ColaboradorModel> Colaboradores { get; set; }

     
    }
}

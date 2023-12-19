using ControleDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public StatusEnum? Perfil { get; set; }
    }
}

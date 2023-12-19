using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ColaboradorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do colaborador")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Unidade não preenchida, caso não tenha unidades por favor cadastrar")]
        public int? UnidadeId { get; set; }        
        public UnidadeModel Unidade { get; set; }
    }
}

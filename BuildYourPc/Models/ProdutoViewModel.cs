using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildYourPc.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 100000.00, ErrorMessage = "O preço deve ser maior que zero.")]
        [Column(TypeName = "decimal(18,2)")] // Garante a formatação correta
        [Display(Name = "Preço (R$)")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório.")]
        [Range(0, 9999, ErrorMessage = "O estoque deve ser entre 0 e 9999.")]
        public int Estoque { get; set; }
    }
}
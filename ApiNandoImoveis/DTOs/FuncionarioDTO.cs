using ApiNandoImoveis.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiNandoImoveis.DTOs
{
    public class FuncionarioDTO
    {  // Informações do Corretor
        [Key]
        public int Id { get; set; }

        [StringLength(100), Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome Completo")]
        public string? Nome { get; set; }

        [StringLength(14), Required(ErrorMessage = "Campo Obrigatório")]
        public string? CPF { get; set; }

        [StringLength(15), Required(ErrorMessage = "Campo Obrigatório")]
        public string? RG { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nasc.")]
        public DateTime DataNascimento { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string? Telefone { get; set; }

        [StringLength(20)]
        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        public string? Celular { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [StringLength(20), Required(ErrorMessage = "Campo Obrigatório")]
        public string? CRECI { get; set; } // Registro do corretor
        public DateTime? DataContratacao { get; set; }

        // Endereço do Corretor
        [StringLength(50), Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "UF")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(8)]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "O CEP deve estar no formato XXXXX-XXX.")]
        public string? CEP { get; set; }

        // Relacionamento com Imóveis (Um corretor pode ser responsável por vários imóveis)
        public virtual ICollection<Imovel> Imoveis { get; set; } = new List<Imovel>();

        // Relacionamento com Clientes (Um corretor pode gerenciar vários clientes)
        public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
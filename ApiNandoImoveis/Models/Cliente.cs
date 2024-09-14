using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNandoImoveis.Models
{
    public class Cliente
    {
        // Informações Pessoais
        public int Id { get; set; }

        [StringLength(100), Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome Completo")]
        public string? NomeCompleto { get; set; }

        [StringLength(14), Required(ErrorMessage = "Campo Obrigatório")]
        public string? CPF { get; set; }

        [StringLength(15), Required(ErrorMessage = "Campo Obrigatório")]
        public string? RG { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nasc.")]
        public DateTime DataNascimento { get; set; }

        [StringLength(15), Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Estado Cívil")]
        public string? EstadoCivil { get; set; }

        [StringLength(50)]
        public string? Nacionalidade { get; set; }

        [StringLength(50)]
        [Display(Name = "Profissão")]
        public string? Profissao { get; set; }

        // Endereço
        [StringLength(50), Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "UF")]
        public string? Estado { get; set; }

        [StringLength(10), Required(ErrorMessage = "Campo Obrigatório")]
        public string? CEP { get; set; }

        [StringLength(50)]
        public string? Complemento { get; set; }

        // Contato
        [StringLength(20), Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
        public string? TelefoneCelular { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone")]
        public string? TelefoneResidencial { get; set; } // opcional

        [StringLength(50), Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        // Informações Financeiras
        [Display(Name = "Renda Mensal")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RendaMensal { get; set; }

        [Display(Name = "Comprovante de renda")]
        [StringLength(100)]
        public string? ComprovanteRenda { get; set; } // poderia ser um caminho para o arquivo no servidor

        [StringLength(50)]
        [Display(Name = "Emprego Atual")]
        public string? EmpregoAtual { get; set; }

        [StringLength(50)]
        [Display(Name = "Inf. Bancárias")]
        public string? InformacoesBancarias { get; set; } // opcional

        // Preferências de Imóvel
        [StringLength (50)]
        [Display(Name ="Tipo de Imovel")]
        public string? TipoImovel { get; set; } // casa, apartamento, terreno, etc.

        [StringLength(50)]
        [Display(Name = "Região Interesse")]
        public string? RegiaoInteresse { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name ="Faixa de Preço")]
        public decimal FaixaPreco { get; set; }

        [StringLength(50)]
        [Display(Name = "Finalidade")]
        public string? Finalidade { get; set; } // compra, locação, investimento

        // Outros
        [StringLength(50)]
        [Display(Name = "Como Conheceu?")]
        public string? ComoConheceu { get; set; }

        [StringLength(50)]
        [Display(Name = "Obs.")]
        public string? Observacoes { get; set; }

        // Relacionamento com Imóvel (Um cliente pode ter muitos imóveis)
        public virtual ICollection<Imovel> Imoveis { get; set; } = new List<Imovel>();
    }
}

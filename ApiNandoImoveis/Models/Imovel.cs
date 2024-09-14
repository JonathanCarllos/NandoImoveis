using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNandoImoveis.Models
{
    public class Imovel
    {
        // Informações Básicas do Imóvel
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo do imóvel é obrigatório.")]
        [StringLength(50)]
        public string? TipoImovel { get; set; } // Casa, Apartamento, Terreno, etc.

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200)]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100)]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2)]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(8)]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "O CEP deve estar no formato XXXXX-XXX.")]
        public string? CEP { get; set; }

        [StringLength(100)]
        public string? Complemento { get; set; }

        // Imagens do Imóvel
        [Required(ErrorMessage = "A URL da imagem é obrigatória.")]
        [Url(ErrorMessage = "A URL da imagem deve ser válida.")]
        public string? ImagemUrl { get; set; }

        [Url(ErrorMessage = "A URL da imagem miniatura deve ser válida.")]
        public string? ImagemTumbler { get; set; }

        // Características do Imóvel
        [Required(ErrorMessage = "A área construída é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "Área construída deve ser um valor positivo.")]
        public int AreaConstruida { get; set; } // em metros quadrados

        [Required(ErrorMessage = "A área total é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "Área total deve ser um valor positivo.")]
        public int AreaTotal { get; set; } // em metros quadrados

        [Required(ErrorMessage = "A quantidade de quartos é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade de quartos deve ser um valor positivo.")]
        public int QuantidadeQuartos { get; set; }

        [Required(ErrorMessage = "A quantidade de banheiros é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade de banheiros deve ser um valor positivo.")]
        public int QuantidadeBanheiros { get; set; }

        [Required(ErrorMessage = "A quantidade de vagas na garagem é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade de vagas na garagem deve ser um valor positivo.")]
        public int QuantidadeVagasGaragem { get; set; }

        [Display(Name = "Possui Suíte?")]
        public bool PossuiSuite { get; set; }

        [Display(Name = "Possui Churrasqueira?")]
        public bool PossuiChurrasqueira { get; set; }

        [Display(Name = "Possui Piscina?")]
        public bool PossuiPiscina { get; set; }

        [Display(Name = "Possui Área de Serviço")]
        public bool PossuiAreaDeServico { get; set; }

        [Display(Name = "Possui Armários Emburtidos?")]
        public bool PossuiArmariosEmbutidos { get; set; }

        // Informações de Venda
        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "É necessário informar se o imóvel está disponível para venda.")]
        public bool DisponivelParaVenda { get; set; }

        [Required(ErrorMessage = "A data de disponibilidade é obrigatória.")]
        public DateTime DataDisponibilidade { get; set; }

        // Novo campo: IPTU
        [Required(ErrorMessage = "O valor do IPTU é obrigatório.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor do IPTU deve ser um valor positivo.")]
        public decimal IPTU { get; set; }

        // Outras Informações
        [Required(ErrorMessage = "O nome do proprietário é obrigatório.")]
        [StringLength(100)]
        public string? ProprietarioNome { get; set; }

        [Required(ErrorMessage = "O contato do proprietário é obrigatório.")]
        [StringLength(50)]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string? ProprietarioContato { get; set; }

        [StringLength(1000)]
        public string? Observacoes { get; set; }

        // Dados de Registro do Imóvel
        [StringLength(50)]
        public string? RegistroImovel { get; set; }

        [StringLength(50)]
        public string? Matricula { get; set; } // número de matrícula do imóvel

        [Required(ErrorMessage = "A data de registro é obrigatória.")]
        public DateTime DataRegistro { get; set; }

        // Relacionamento com Cliente (Um imóvel pertence a um cliente)
        [Required(ErrorMessage = "O cliente relacionado é obrigatório.")]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; } // Chave estrangeira

        public virtual Cliente? Cliente { get; set; } // Navegação para o cliente
    }
}

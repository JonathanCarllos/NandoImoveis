namespace ApiNandoImoveis.Models
{
    public class Imovel
    {
        // Informações Básicas do Imóvel
        public int Id { get; set; }
        public string? TipoImovel { get; set; } // Casa, Apartamento, Terreno, etc.
        public string? Descricao { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public string? Complemento { get; set; }

        //Imagens do Imóvel
        public string? ImagemUrl { get; set; }
        public string? ImagemTumbler { get; set; }

        // Características do Imóvel
        public int AreaConstruida { get; set; } // em metros quadrados
        public int AreaTotal { get; set; } // em metros quadrados
        public int QuantidadeQuartos { get; set; }
        public int QuantidadeBanheiros { get; set; }
        public int QuantidadeVagasGaragem { get; set; }
        public bool PossuiSuite { get; set; }
        public bool PossuiChurrasqueira { get; set; }
        public bool PossuiPiscina { get; set; }
        public bool PossuiAreaDeServico { get; set; }
        public bool PossuiArmariosEmbutidos { get; set; }

        // Informações de Venda
        public decimal Preco { get; set; }
        public bool DisponivelParaVenda { get; set; }
        public DateTime DataDisponibilidade { get; set; }

        // Outras Informações
        public string? ProprietarioNome { get; set; }
        public string? ProprietarioContato { get; set; }
        public string? Observacoes { get; set; }

        // Dados de Registro do Imóvel
        public string? RegistroImovel { get; set; }
        public string? Matricula { get; set; } // número de matrícula do imóvel
        public DateTime DataRegistro { get; set; }

        // Relacionamento com Cliente (Um imóvel pertence a um cliente)
        public int ClienteId { get; set; } // Chave estrangeira
        public virtual Cliente? Cliente { get; set; } // Navegação para o cliente
    }
}

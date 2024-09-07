namespace ApiNandoImoveis.Models
{
    public class Cliente
    {
        // Informações Pessoais
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Nacionalidade { get; set; }
        public string? Profissao { get; set; }

        // Endereço
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public string? Complemento { get; set; }

        // Contato
        public string? TelefoneCelular { get; set; }
        public string? TelefoneResidencial { get; set; } // opcional
        public string? Email { get; set; }

        // Informações Financeiras
        public decimal RendaMensal { get; set; }
        public string? ComprovanteRenda { get; set; } // poderia ser um caminho para o arquivo no servidor
        public string? EmpregoAtual { get; set; }
        public string? InformacoesBancarias { get; set; } // opcional

        // Preferências de Imóvel
        public string? TipoImovel { get; set; } // casa, apartamento, terreno, etc.
        public string? RegiaoInteresse { get; set; }
        public decimal FaixaPreco { get; set; }
        public string? Finalidade { get; set; } // compra, locação, investimento

        // Outros
        public string? ComoConheceu { get; set; }
        public string? Observacoes { get; set; }

        // Relacionamento com Imóvel (Um cliente pode ter muitos imóveis)
        public virtual ICollection<Imovel> Imoveis { get; set; } = new List<Imovel>();
    }
}

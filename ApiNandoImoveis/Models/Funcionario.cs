namespace ApiNandoImoveis.Models
{
    public class Funcionario
    {
        // Informações do Corretor
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? CRECI { get; set; } // Registro do corretor
        public DateTime? DataContratacao { get; set; }

        // Endereço do Corretor
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }

        // Relacionamento com Imóveis (Um corretor pode ser responsável por vários imóveis)
        public virtual ICollection<Imovel> Imoveis { get; set; } = new List<Imovel>();

        // Relacionamento com Clientes (Um corretor pode gerenciar vários clientes)
        public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
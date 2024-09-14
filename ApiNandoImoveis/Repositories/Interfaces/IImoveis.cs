using ApiNandoImoveis.Models;

namespace ApiNandoImoveis.Repositories.Interfaces
{
    public interface IImoveis
    {
        Task<IEnumerable<Imovel>> GetAll();
        Task<IEnumerable<Imovel>> GetImoveisClientes();
        Task<Imovel> GetById(int Id);
        Task<Imovel> Create(Imovel imovel);
        Task<Imovel> Update(Imovel imovel);
        Task<Imovel> Delete(int Id);

    }
}

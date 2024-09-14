using ApiNandoImoveis.Models;

namespace ApiNandoImoveis.Repositories.Interfaces
{
    public interface ICliente
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task<Cliente> Create(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
        Task<Cliente> Delete(int id);
    }
}

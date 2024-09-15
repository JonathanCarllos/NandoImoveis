using ApiNandoImoveis.DTOs;

namespace ApiNandoImoveis.Services.Interfaces
{
    public interface IClienteServices
    {
        Task<IEnumerable<ClienteDTO>> GetClientes();
        Task<ClienteDTO> GetClientesById(int id);
        Task AddCliente(ClienteDTO cliente);
        Task UpgradeCliente(ClienteDTO cliente);
        Task RemoveCliente(int id);

    }
}

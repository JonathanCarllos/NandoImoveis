using ApiNandoImoveis.DTOs;

namespace ApiNandoImoveis.Services.Interfaces
{
    public interface IImoveisServices
    {
        Task<IEnumerable<ImovelDTO>> GetImoveis();
        Task<IEnumerable<ImovelDTO>> GetImovelClientes();
        Task<ImovelDTO> GetImovelById(int id); 
        Task AddImovel(ImovelDTO imovelDTO);
        Task Upgrade(ImovelDTO imovelDTO);
        Task RemoveImovel(int id);
    }
}

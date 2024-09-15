using ApiNandoImoveis.DTOs;

namespace ApiNandoImoveis.Services.Interfaces
{
    public interface IFuncionarioServices
    {
        Task<IEnumerable<FuncionarioDTO>> GetFuncionario();
        Task<FuncionarioDTO> GetFuncionarioById(int id);
        Task AddFuncionario(FuncionarioDTO funcionario);
        Task UpgradeFuncionario(FuncionarioDTO funcionario);
        Task RemoveFuncionario(int id);
    }
}

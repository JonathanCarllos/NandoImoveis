using ApiNandoImoveis.Models;

namespace ApiNandoImoveis.Repositories.Interfaces
{
    public interface IFuncionario
    {
        Task<IEnumerable<Funcionario>> GetAll();
        Task<Funcionario> GetById(int id);
        Task<Funcionario> Create(Funcionario funcionario);
        Task<Funcionario> Update(Funcionario funcionario);
        Task<Funcionario> Delete(int id);
    }
}

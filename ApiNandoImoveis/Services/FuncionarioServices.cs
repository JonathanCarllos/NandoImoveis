using ApiNandoImoveis.DTOs;
using ApiNandoImoveis.Models;
using ApiNandoImoveis.Repositories.Interfaces;
using ApiNandoImoveis.Services.Interfaces;
using AutoMapper;

namespace ApiNandoImoveis.Services
{
    public class FuncionarioServices : IFuncionarioServices
    {
        private readonly IFuncionario _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioServices(IFuncionario funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task AddFuncionario(FuncionarioDTO funcionario)
        {
            var funcionarioEntity = _mapper.Map<Funcionario>(funcionario);
            await _funcionarioRepository.Create(funcionarioEntity);
            funcionario.Id = funcionarioEntity.Id;
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetFuncionario()
        {
            var funcionarioEntity = await _funcionarioRepository.GetAll();
            return _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarioEntity);
        }

        public async Task<FuncionarioDTO> GetFuncionarioById(int id)
        {
            var funcionarioEntity = await _funcionarioRepository.GetById(id);
            return _mapper.Map<FuncionarioDTO>(funcionarioEntity);
        }

        public async Task RemoveFuncionario(int id)
        {
            var funcionarioEntity = await _funcionarioRepository.GetById(id);
            await _funcionarioRepository.Delete(funcionarioEntity.Id);
        }

        public async Task UpgradeFuncionario(FuncionarioDTO funcionario)
        {
            var funcionarioEntity = _mapper.Map<Funcionario>(funcionario);
            await _funcionarioRepository.Update(funcionarioEntity);
        }
    }
}

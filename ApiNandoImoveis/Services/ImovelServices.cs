using ApiNandoImoveis.DTOs;
using ApiNandoImoveis.Models;
using ApiNandoImoveis.Repositories.Interfaces;
using ApiNandoImoveis.Services.Interfaces;
using AutoMapper;

namespace ApiNandoImoveis.Services
{
    public class ImovelServices : IImoveisServices
    {
        private readonly IImoveis _imoveisRepository;
        private readonly IMapper _mapper;

        public ImovelServices(IImoveis imoveisRepository, IMapper mapper)
        {
            _imoveisRepository = imoveisRepository;
            _mapper = mapper;
        }

        public async Task AddImovel(ImovelDTO imovelDTO)
        {
            var imovelEntity = _mapper.Map<Imovel>(imovelDTO);
            await _imoveisRepository.Create(imovelEntity);
            imovelDTO.Id = imovelEntity.Id;
        }

        public async Task<IEnumerable<ImovelDTO>> GetImoveis()
        {
            var imoveisEntity = await _imoveisRepository.GetAll();
            return _mapper.Map<IEnumerable<ImovelDTO>>(imoveisEntity);
        }

        public async Task<ImovelDTO> GetImovelById(int id)
        {
            var imoveisEntity = await _imoveisRepository.GetById(id);
            return _mapper.Map<ImovelDTO>(imoveisEntity);
        }

        public async Task<IEnumerable<ImovelDTO>> GetImovelClientes()
        {
            var imoveisEntity = await _imoveisRepository.GetImoveisClientes();
            return _mapper.Map<IEnumerable<ImovelDTO>>(imoveisEntity);
        }

        public async Task RemoveImovel(int id)
        {
            var imoveisEntity = _imoveisRepository.GetById(id).Result;
            await _imoveisRepository.Delete(imoveisEntity.Id);
        }

        public async Task Upgrade(ImovelDTO imovelDTO)
        {
            var imovelEntity = _mapper.Map<Imovel>(imovelDTO);
            await _imoveisRepository.Update(imovelEntity);
        }
    }
}

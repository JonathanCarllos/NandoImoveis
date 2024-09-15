using ApiNandoImoveis.DTOs;
using ApiNandoImoveis.Models;
using ApiNandoImoveis.Repositories.Interfaces;
using ApiNandoImoveis.Services.Interfaces;
using AutoMapper;

namespace ApiNandoImoveis.Services
{
    public class ClientesServices : IClienteServices
    {
        private readonly ICliente _clienteRepository;
        private readonly IMapper _mapper;

        public ClientesServices(ICliente clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task AddCliente(ClienteDTO cliente)
        {
            var clienteEntity = _mapper.Map<Cliente>(cliente);
            await _clienteRepository.Create(clienteEntity);
            cliente.Id = clienteEntity.Id;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            var clientesEntity = await _clienteRepository.GetAll();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientesEntity);
        }

        public async Task<ClienteDTO> GetClientesById(int id)
        {
            var clientesEntity = await _clienteRepository.GetById(id);
            return _mapper.Map<ClienteDTO>(clientesEntity);
        }

        public async Task RemoveCliente(int id)
        {
            var clienteEntity = await _clienteRepository.GetById(id);
            await _clienteRepository.Delete(clienteEntity.Id);
        }

        public async Task UpgradeCliente(ClienteDTO cliente)
        {
            var clienteEntity = _mapper.Map<Cliente>(cliente);
            await _clienteRepository.Update(clienteEntity);
        }
    }
}

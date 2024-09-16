using ApiNandoImoveis.DTOs;
using ApiNandoImoveis.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNandoImoveis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;

        public ClientesController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clienteDTO = await _clienteServices.GetClientes();

            if (clienteDTO == null)
            {
                return NotFound("Clientes não encontrado");
            }

            return Ok(clienteDTO);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var clienteDTO = await _clienteServices.GetClientesById(id);

            if (clienteDTO == null)
            {
                return NotFound("Clientes não encontrado");
            }

            return Ok(clienteDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
                return BadRequest("Dados inválidos");

            await _clienteServices.UpgradeCliente(clienteDTO);
            return new CreatedAtRouteResult("GetClientes", new { id = clienteDTO.Id }, clienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.Id)
            {
                return BadRequest("Dados inválidos");
            }

            if (clienteDTO == null)
                return BadRequest("Dados inválidos");

            await _clienteServices.UpgradeCliente(clienteDTO);

            return Ok(clienteDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var clienteDTO = await _clienteServices.GetClientesById(id);

            if(clienteDTO == null)
            {
                return NotFound("Cliente não encontrado");
            }

            await _clienteServices.RemoveCliente(id);

            return Ok(clienteDTO);
        }
    }
}

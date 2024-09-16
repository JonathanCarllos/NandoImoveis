using ApiNandoImoveis.DTOs;
using ApiNandoImoveis.Services;
using ApiNandoImoveis.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNandoImoveis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioServices _funcionarioServices;

        public FuncionariosController(IFuncionarioServices funcionarioServices)
        {
            _funcionarioServices = funcionarioServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDTO>>> Get()
        {
            var funcionarioDTO = await _funcionarioServices.GetFuncionario();

            if (funcionarioDTO == null)
            {
                return NotFound("Funcionarios não encontrado");
            }

            return Ok(funcionarioDTO);
        }

        [HttpGet("{id}", Name = "GetFuncionario")]
        public async Task<ActionResult<FuncionarioDTO>> Get(int id)
        {
            var funcionarioDTO = await _funcionarioServices.GetFuncionarioById(id);

            if (funcionarioDTO == null)
            {
                return NotFound("Funcionario não encontrado");
            }

            return Ok(funcionarioDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FuncionarioDTO funcionarioDTO)
        {
            if (funcionarioDTO == null)
                return BadRequest("Dados inválidos");

            await _funcionarioServices.UpgradeFuncionario(funcionarioDTO);
            return new CreatedAtRouteResult("GetFuncionarios", new { id = funcionarioDTO.Id }, funcionarioDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FuncionarioDTO funcionarioDTO)
        {
            if (id != funcionarioDTO.Id)
            {
                return BadRequest("Dados inválidos");
            }

            if (funcionarioDTO == null)
                return BadRequest("Dados inválidos");

            await _funcionarioServices.UpgradeFuncionario(funcionarioDTO);

            return Ok(funcionarioDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FuncionarioDTO>> Delete(int id)
        {
            var funcionarioDTO = await _funcionarioServices.GetFuncionarioById(id);

            if (funcionarioDTO == null)
            {
                return NotFound("Funcionário  não encontrado");
            }

            await _funcionarioServices.RemoveFuncionario(id);

            return Ok(funcionarioDTO);
        }
    }
}

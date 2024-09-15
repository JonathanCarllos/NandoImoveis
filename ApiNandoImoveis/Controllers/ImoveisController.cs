using ApiNandoImoveis.DTOs;
using ApiNandoImoveis.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNandoImoveis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly IImoveisServices _imoveisServices;

        public ImoveisController(IImoveisServices imoveisServices)
        {
            _imoveisServices = imoveisServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImovelDTO>>> Get()
        {
            var imoveisDTO = await _imoveisServices.GetImoveis();

            if (imoveisDTO is null)
                return NotFound("Imóveis não encontrado");

            return Ok(imoveisDTO);
        }

        [HttpGet("Clientes")]
        public async Task<ActionResult<IEnumerable<ImovelDTO>>> GetImoveisClientes()
        {
            var imoveisDTO = await _imoveisServices.GetImovelClientes();

            if (imoveisDTO == null)
            {
                return NotFound("Imóveis não encontrado");
            }
            return Ok(imoveisDTO);
        }

        [HttpGet("{id:int}", Name = "GetClientes")]
        public async Task<ActionResult<ImovelDTO>> Get(int id)
        {
            var imoveisDTO = await _imoveisServices.GetImovelById(id);
            if (imoveisDTO == null)
            {
                return NotFound("Cliente não encontrado");
            }
            return Ok(imoveisDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ImovelDTO imovelDTO)
        {
            if (imovelDTO == null)
                return BadRequest("Dados inválidos");

            await _imoveisServices.AddImovel(imovelDTO);
            return new CreatedAtRouteResult("GetImoveis", new { id = imovelDTO.Id }, imovelDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ImovelDTO imovelDTO)
        {
            if (id != imovelDTO.Id)
                return BadRequest();

            if (imovelDTO == null)
                return BadRequest();

            await _imoveisServices.Upgrade(imovelDTO);
            return Ok(imovelDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ImovelDTO>> Delete(int id)
        {
            var imoveisDTO = await _imoveisServices.GetImovelById(id);
            if(imoveisDTO == null)
            {
                return NotFound();
            }

            await _imoveisServices.RemoveImovel(id);

            return Ok(imoveisDTO);
        }

    }
}

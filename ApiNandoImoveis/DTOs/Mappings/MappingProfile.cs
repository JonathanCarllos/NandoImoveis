using ApiNandoImoveis.Models;
using AutoMapper;

namespace ApiNandoImoveis.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<Imovel, ImovelDTO>().ReverseMap();        
        }
    }
}

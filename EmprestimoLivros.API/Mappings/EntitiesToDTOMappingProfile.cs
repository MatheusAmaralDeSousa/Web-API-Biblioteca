using AutoMapper;
using EmprestimoLivros.API.DTOs;
using EmprestimoLivros.API.Modelos;

namespace EmprestimoLivros.API.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {   
            //Aqui vamos mapear as relações entre Entidades e os DTOS
            //Entidade, DTO
            //ReverseMap(), utilizado para haver a possibilidade de passar informações tanto de Cliente para ClienteDTO, quanto ClienteDTO para Cliente.
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}

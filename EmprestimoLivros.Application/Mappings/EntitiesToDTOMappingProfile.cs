using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Modelos;

namespace EmprestimoLivros.Application.Mappings
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

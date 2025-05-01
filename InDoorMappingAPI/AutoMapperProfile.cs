using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.Models;

namespace InDoorMappingAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Caminho, GetCaminhoDTO>()
                .ForMember(dest => dest.TipoAcessibilidade, opt =>
                    opt.MapFrom(src => src.Acessibilidade != null ? src.Acessibilidade.Tipo : "Desconhecido"));
            CreateMap<Infraestrutura, GetInfraestruturaDTO>()
                .ForMember(dest => dest.InfraestruturaId, opt => 
                    opt.MapFrom(src => src.Id));
            CreateMap<Usuario, GetUsuarioDTO>()
            .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.TipoUsuario.Tipo))
            .ForMember(dest => dest.MobilidadeTipo, opt => opt.MapFrom(src => src.Mobilidade.Tipo));
        }
    }
}

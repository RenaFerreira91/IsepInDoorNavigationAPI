using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.DTOs.PUTs.InDoorMappingAPI.DTOs.PUTs;
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
            CreateMap<PostCaminhoDTO, Caminho>();
            CreateMap<PutCaminhoDTO, Caminho>();

            CreateMap<Infraestrutura, GetInfraestruturaDTO>()
                .ForMember(dest => dest.TipoInfraestrutura, opt => opt.MapFrom(src => src.TipoInfraestrutura.Tipo));
            CreateMap<PostInfraestruturaDTO, Infraestrutura>();
            CreateMap<PutInfraestruturaDTO, Infraestrutura>();

            CreateMap<Usuario, GetUsuarioDTO>()
            .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.TipoUsuario.Tipo))
            .ForMember(dest => dest.MobilidadeTipo, opt => opt.MapFrom(src => src.Mobilidade.Tipo));
            
            CreateMap<Beacon, GetBeaconDTO>();
            CreateMap<PostBeaconDTO, Beacon>();
            CreateMap<PutBeaconDTO, Beacon>();

            CreateMap<Acessibilidade, GetAcessibilidadeDTO>();
            CreateMap<PostAcessibilidadeDTO, Acessibilidade>();
            CreateMap<PutAcessibilidadeDTO, Acessibilidade>();

            CreateMap<Log, GetLogDTO>()
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.Usuario.UsuarioId));

            CreateMap<PostLogDTO, Log>();

        }
    }
}

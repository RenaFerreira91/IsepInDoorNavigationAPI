using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;

namespace InDoorMappingAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Caminho, GetCaminhoDTO>()
                .ForMember(dest => dest.TipoAcessibilidade, opt =>
                    opt.MapFrom(src => src.Acessibilidade != null ? src.Acessibilidade.Tipo : "Desconhecido"));
        }
    }
}

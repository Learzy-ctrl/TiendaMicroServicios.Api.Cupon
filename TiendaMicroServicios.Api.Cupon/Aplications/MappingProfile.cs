using AutoMapper;
using TiendaMicroServicios.Api.Cupon.Models.Dto;

namespace TiendaMicroServicios.Api.Cupon.Aplications
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CuponDto, Cupon.Models.Cupon>();
            CreateMap<Cupon.Models.Cupon, CuponDto>();
        }
    }
}

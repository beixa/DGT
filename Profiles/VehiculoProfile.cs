using AutoMapper;
using DGT.DTOs;
using DGT.Models;

namespace DGT.Profiles
{
    public class VehiculoProfile : Profile
    {
        public VehiculoProfile()
        {
            CreateMap<Vehiculo, VehiculoDTO>()
                .ForMember(v => v.Conductores, opt => opt.MapFrom<VehiculoResolver>());
        }
    }
}
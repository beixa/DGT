using AutoMapper;
using DGT.DTOs;
using DGT.Models;

namespace DGT.Profiles
{
    public class ConductorProfile : Profile
    {
        public ConductorProfile ()
        {
            CreateMap<Conductor, ConductorDTO>()
                .ForMember(c => c.Vehiculos, opt => opt.MapFrom<ConductorResolver>());
        }
    }
}
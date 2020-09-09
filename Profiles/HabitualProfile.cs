using AutoMapper;
using DGT.DTOs;
using DGT.Models;

namespace DGT.Profiles
{
    public class HabitualProfile : Profile
    {
        public HabitualProfile()
        {
            CreateMap<ConductorVehiculo, HabitualDTO>();
        }
    }
}
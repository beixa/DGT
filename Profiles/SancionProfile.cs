using AutoMapper;
using DGT.DTOs;
using DGT.Models;

namespace DGT.Profiles
{
    public class SancionProfile : Profile
    {
        public SancionProfile()
        {            
            CreateMap<Sancion, SancionDTO>()
                .ForMember(s => s.Conductor, opt => opt.MapFrom(s => new InfoConductor
                                                                    {
                                                                        Dni = s.Conductor.Dni,
                                                                        Nombre = s.Conductor.Nombre,
                                                                        Apellidos = s.Conductor.Apellidos,
                                                                        Puntos = s.Conductor.Puntos
                                                                    }))
                .ForMember(s => s.Vehiculo, opt => opt.MapFrom(s => new InfoVehiculo
                                                                    {
                                                                        Matricula = s.Vehiculo.Matricula,
                                                                        Marca = s.Vehiculo.Marca,
                                                                        Modelo = s.Vehiculo.Modelo,
                                                                        Infraccion = s.Vehiculo.Infraccion
                                                                    }));
        }
    }
}
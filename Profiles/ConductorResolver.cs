using System.Collections.Generic;
using AutoMapper;
using DGT.DTOs;
using DGT.Models;

namespace DGT.Profiles
{
    public class ConductorResolver : IValueResolver<Conductor, ConductorDTO, List<InfoVehiculo>>
    {
        public List<InfoVehiculo> Resolve(Conductor source, ConductorDTO destination, List<InfoVehiculo> destMember, ResolutionContext context)
        {
             var vehiculos = new List<InfoVehiculo>();

            if(source.ConductorVehiculos == null)
            {
                return null;
            }
            
            foreach (var vehiculo in source.ConductorVehiculos)
            {
                var infoVehiculo = new InfoVehiculo
                {
                    Matricula = vehiculo.Matricula,
                    Marca = vehiculo.Vehiculo.Marca,
                    Modelo = vehiculo.Vehiculo.Modelo,
                    Infraccion = vehiculo.Vehiculo.Infraccion
                };

                vehiculos.Add(infoVehiculo);
            }

            return vehiculos;
        }
    }
}
using System.Collections.Generic;
using AutoMapper;
using DGT.DTOs;
using DGT.Models;

namespace DGT.Profiles
{
    public class VehiculoResolver : IValueResolver<Vehiculo, VehiculoDTO, List<InfoConductor>>
    {
        public List<InfoConductor> Resolve(Vehiculo source, VehiculoDTO destination, List<InfoConductor> destMember, ResolutionContext context)
        {
             var conductores = new List<InfoConductor>();

            if(source.ConductorVehiculos == null)
            {
                return null;
            }
            
            foreach (var conductor in source.ConductorVehiculos)
            {
                var infoConductor = new InfoConductor
                {
                    Dni = conductor.Dni,
                    Nombre = conductor.Conductor.Nombre,
                    Apellidos = conductor.Conductor.Apellidos,
                    Puntos = conductor.Conductor.Puntos
                };
                conductores.Add(infoConductor);
            }

            return conductores;
        }
    }
}
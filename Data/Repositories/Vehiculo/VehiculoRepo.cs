using System;
using System.Collections.Generic;
using System.Linq;
using DGT.Models;
using Microsoft.EntityFrameworkCore;

namespace DGT.Data.Repositories
{
    public class VehiculoRepo : IVehiculoRepo
    {
        private readonly DataContext _ctx;

        public VehiculoRepo(DataContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateInfraccionInVehiculo(Vehiculo vehiculo, Infraccion infraccion, IEnumerable<ConductorVehiculo> habituales)
        {
            vehiculo.Infraccion = infraccion;

           //No esta bien formulado el problema, puede haber mas de un conductor habitual por vehiculo y no se sabe cual coger
           //Cojo el primero que encuentro
           var habitual = habituales.FirstOrDefault(x => x.Matricula.Equals(vehiculo.Matricula));

           var conductor = habitual.Conductor;
           conductor.Puntos = conductor.Puntos - infraccion.DescuentoPuntos;

           var sancion = new Sancion{
               Fecha = DateTime.Now,
               Conductor = conductor,
               Vehiculo = vehiculo,
           };

           _ctx.Sanciones.Add(sancion);
           _ctx.SaveChanges();
        }

        public void CreateVehiculo(Vehiculo vehiculo)
        {
           if (vehiculo == null)
            {
                throw new ArgumentNullException(nameof(vehiculo));
            }

            _ctx.Vehiculos.Add(vehiculo);
        }

        public IEnumerable<Vehiculo> GetAllVehiculos()
        {
             return _ctx.Vehiculos.Include(v => v.Infraccion)
                                    .Include(c => c.ConductorVehiculos)
                                    .ThenInclude(cv => cv.Conductor).ToList();
        }

        public Vehiculo GetVehiculoById(string matricula)
        {
             return _ctx.Vehiculos.FirstOrDefault(x => x.Matricula.Equals(matricula));
        }

        public bool SaveChanges()
        {
            return (_ctx.SaveChanges() >= 0);
        }
    }
}
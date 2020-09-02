using System;
using System.Collections.Generic;
using System.Linq;
using DGT.Models;

namespace DGT.Data
{
    public class DGTRepo : IDGTRepo
    {
        private readonly DataContext _ctx;

        public DGTRepo(DataContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateConductor(Conductor conductor)
        {
            if (conductor == null)
            {
                throw new ArgumentNullException(nameof(conductor));
            }

            _ctx.Conductores.Add(conductor);
        }

        public void CreateHabitual(ConductorVehiculo habitual)
        {
           if (habitual == null)
            {
                throw new ArgumentNullException(nameof(habitual));
            }

            _ctx.ConductorVehiculos.Add(habitual);
        }

        public void CreateInfraccion(Infraccion infraccion)
        {
           if (infraccion == null)
            {
                throw new ArgumentNullException(nameof(infraccion));
            }

            _ctx.Infracciones.Add(infraccion);
        }

        public void CreateInfraccionInVehiculo(string matricula, int id)
        {
           var vehiculo = GetVehiculoById(matricula);

           var infraccion = GetInfraccionById(id);
           vehiculo.Infraccion = infraccion;

           //No esta bien formulado el problema, puede haber mas de un conductor habitual por vehiculo y no se sabe cual coger
           //Cojo el primero que encuentro
           var habitual = GetAllHabituales().FirstOrDefault(x => x.Matricula.Equals(matricula));

           var conductor = GetConductorById(habitual.Dni);
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

        public IEnumerable<Conductor> GetAllConductores()
        {
            return _ctx.Conductores.ToList();
        }

        public IEnumerable<ConductorVehiculo> GetAllHabituales()
        {
            return _ctx.ConductorVehiculos.ToList();
        }

        public IEnumerable<Infraccion> GetAllInfracciones()
        {
            return _ctx.Infracciones.ToList();
        }

        public IEnumerable<Sancion> GetAllSanciones()
        {
            return _ctx.Sanciones.ToList();
        }

        public IEnumerable<Vehiculo> GetAllVehiculos()
        {
            return _ctx.Vehiculos.ToList();
        }

        public Conductor GetConductorById(string dni)
        {
            return _ctx.Conductores.FirstOrDefault(x => x.Dni.Equals(dni));
        }

        public ConductorVehiculo GetHabitualByDniAndMatricula(string dni, string matricula)
        {
            return _ctx.ConductorVehiculos.FirstOrDefault(x => x.Dni.Equals(dni) && x.Matricula.Equals(matricula));
        }
        public IEnumerable<ConductorVehiculo> GetHabitualesByDni(string dni)
        {
            return _ctx.ConductorVehiculos.Where(x => x.Dni.Equals(dni)).ToList();
        }

        public Infraccion GetInfraccionById(int id)
        {
            return _ctx.Infracciones.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Conductor> GetNConductores(int N)
        {
            return _ctx.Conductores.Take(N).ToList();
        }

        public IEnumerable<Sancion> GetSancionesByDni(string dni)
        {
            return _ctx.Sanciones.Where(x => x.Conductor.Dni.Equals(dni)).ToList();
        }

        public IEnumerable<string> GetSancionesHabituales(int cnt)
        {
            var sanciones =  _ctx.Sanciones.GroupBy(x => x.Vehiculo.Infraccion.Descripcion)
                          .OrderByDescending(gp => gp.Count())
                          .Take(cnt)
                          .Select(g => g.Key)
                          .ToList();
            
            return sanciones; 
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
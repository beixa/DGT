using System;
using System.Collections.Generic;
using System.Linq;
using DGT.Models;
using Microsoft.EntityFrameworkCore;

namespace DGT.Data.Repositories
{
    public class HabitualesRepo : IHabitualesRepo
    {
        private readonly DataContext _ctx;

        public HabitualesRepo(DataContext ctx)
        {
            _ctx = ctx;
        }
        
        public void CreateHabitual(ConductorVehiculo habitual)
        {
            if (habitual == null)
            {
                throw new ArgumentNullException(nameof(habitual));
            }

            _ctx.ConductorVehiculos.Add(habitual);
        }

        public IEnumerable<ConductorVehiculo> GetAllHabituales()
        {
             return _ctx.ConductorVehiculos.Include(cv =>cv.Conductor)
                                            .Include(cv => cv.Vehiculo).ToList();
        }

        public ConductorVehiculo GetHabitualByDniAndMatricula(string dni, string matricula)
        {
            return _ctx.ConductorVehiculos.FirstOrDefault(x => x.Dni.Equals(dni) && x.Matricula.Equals(matricula));
        }

        public IEnumerable<ConductorVehiculo> GetHabitualesByDni(string dni)
        {
            return _ctx.ConductorVehiculos.Where(x => x.Dni.Equals(dni)).ToList();
        }

        public bool SaveChanges()
        {
            return (_ctx.SaveChanges() >= 0);
        }
    }
}
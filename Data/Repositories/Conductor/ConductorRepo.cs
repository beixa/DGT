using System;
using System.Collections.Generic;
using System.Linq;
using DGT.Models;
using Microsoft.EntityFrameworkCore;

namespace DGT.Data
{
    public class ConductorRepo : IConductorRepo
    {
        private readonly DataContext _ctx;

        public ConductorRepo(DataContext ctx)
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

        public IEnumerable<Conductor> GetAllConductores()
        {
            return _ctx.Conductores.Include(c => c.ConductorVehiculos)
                                    .ThenInclude(cv => cv.Vehiculo).ToList();
        }

        public Conductor GetConductorById(string dni)
        {
            return _ctx.Conductores.Include(c => c.ConductorVehiculos)
                                    .ThenInclude(cv => cv.Vehiculo)
                                    .FirstOrDefault(x => x.Dni.Equals(dni));
        }

        public IEnumerable<Conductor> GetNConductores(int N)
        {
            return _ctx.Conductores.Include(c => c.ConductorVehiculos)
                                    .ThenInclude(cv => cv.Vehiculo)
                                    .Take(N).ToList();
        }

        public bool SaveChanges()
        {
             return (_ctx.SaveChanges() >= 0);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using DGT.Models;
using Microsoft.EntityFrameworkCore;

namespace DGT.Data.Repositories
{
    public class SancionRepo : ISancionRepo
    {
        private readonly DataContext _ctx;

        public SancionRepo(DataContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Sancion> GetAllSanciones()
        {
             return _ctx.Sanciones.Include(s =>s.Conductor)
                                    .Include(s => s.Vehiculo)
                                    .ThenInclude(v => v.Infraccion).ToList();
        }

        public IEnumerable<Sancion> GetSancionesByDni(string dni)
        {
            return _ctx.Sanciones.Include(s =>s.Conductor)
                                    .Include(s => s.Vehiculo)
                                    .ThenInclude(v => v.Infraccion)
                                    .Where(x => x.Conductor.Dni.Equals(dni))
                                    .ToList();
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

        public bool SaveChanges()
        {
           return (_ctx.SaveChanges() >= 0);
        }
    }
}
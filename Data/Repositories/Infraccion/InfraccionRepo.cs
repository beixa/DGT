using System;
using System.Collections.Generic;
using System.Linq;
using DGT.Models;

namespace DGT.Data.Repositories
{
    public class InfraccionRepo : IInfraccionRepo
    {
        private readonly DataContext _ctx;

        public InfraccionRepo(DataContext ctx)
        {
            _ctx = ctx;
        }
        public void CreateInfraccion(Infraccion infraccion)
        {
             if (infraccion == null)
            {
                throw new ArgumentNullException(nameof(infraccion));
            }

            _ctx.Infracciones.Add(infraccion);
        }

        public IEnumerable<Infraccion> GetAllInfracciones()
        {
            return _ctx.Infracciones.ToList();
        }

        public Infraccion GetInfraccionById(int id)
        {
             return _ctx.Infracciones.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_ctx.SaveChanges() >= 0);
        }
    }
}
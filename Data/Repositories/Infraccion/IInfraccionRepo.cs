using System.Collections.Generic;
using DGT.Models;

namespace DGT.Data.Repositories
{
    public interface IInfraccionRepo
    {
        bool SaveChanges();
        void CreateInfraccion (Infraccion infraccion);
        IEnumerable<Infraccion> GetAllInfracciones();
        Infraccion GetInfraccionById(int id);
    }
}
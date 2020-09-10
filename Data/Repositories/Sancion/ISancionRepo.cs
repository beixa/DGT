using System.Collections.Generic;
using DGT.Models;

namespace DGT.Data.Repositories
{
    public interface ISancionRepo
    {
        bool SaveChanges();
        IEnumerable<Sancion> GetAllSanciones();
        IEnumerable<Sancion> GetSancionesByDni(string dni);
        IEnumerable<string> GetSancionesHabituales(int cnt); 
    }
}
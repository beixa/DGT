using System.Collections.Generic;
using DGT.Models;

namespace DGT.Data
{
    public interface IConductorRepo
    {
       bool SaveChanges();
       IEnumerable<Conductor> GetAllConductores();  
       Conductor GetConductorById(string dni);
       void CreateConductor (Conductor conductor);
       IEnumerable<Conductor> GetNConductores (int N);
    }
}
using System.Collections.Generic;
using DGT.Models;

namespace DGT.Data.Repositories
{
    public interface IHabitualesRepo
    {
        bool SaveChanges();
       IEnumerable<ConductorVehiculo> GetAllHabituales(); 
       IEnumerable<ConductorVehiculo> GetHabitualesByDni(string dni);
       ConductorVehiculo GetHabitualByDniAndMatricula (string dni, string matricula);
       void CreateHabitual (ConductorVehiculo habitual); 
    }
}
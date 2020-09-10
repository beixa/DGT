using System.Collections.Generic;
using DGT.Models;

namespace DGT.Data
{
    public interface IVehiculoRepo
    {
       bool SaveChanges();
       IEnumerable<Vehiculo> GetAllVehiculos();
       Vehiculo GetVehiculoById(string matricula);
       void CreateVehiculo (Vehiculo vehiculo);  
       void CreateInfraccionInVehiculo (Vehiculo vehiculo, Infraccion infraccion, IEnumerable<ConductorVehiculo> habitual);
       //void CreateInfraccionInVehiculo (string matricula, int id);
    }
}
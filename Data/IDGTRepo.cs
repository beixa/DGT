using System.Collections.Generic;
using DGT.Models;

namespace DGT.Data
{
    public interface IDGTRepo
    {
       bool SaveChanges();
       IEnumerable<Conductor> GetAllConductores();  
       Conductor GetConductorById(string dni);
       void CreateConductor (Conductor conductor);
       IEnumerable<Vehiculo> GetAllVehiculos();
       Vehiculo GetVehiculoById(string matricula);
       void CreateVehiculo (Vehiculo vehiculo);
       IEnumerable<ConductorVehiculo> GetAllHabituales(); 
       IEnumerable<ConductorVehiculo> GetHabitualesByDni(string dni);
       ConductorVehiculo GetHabitualByDniAndMatricula (string dni, string matricula);
       void CreateHabitual (ConductorVehiculo habitual);
       void CreateInfraccion (Infraccion infraccion);
       IEnumerable<Infraccion> GetAllInfracciones();
       Infraccion GetInfraccionById(int id);
       void CreateInfraccionInVehiculo (string matricula, int id);
       IEnumerable<Conductor> GetNConductores (int N);
       IEnumerable<Sancion> GetAllSanciones();
       IEnumerable<Sancion> GetSancionesByDni(string dni);
       IEnumerable<string> GetSancionesHabituales(int cnt);
    }
}
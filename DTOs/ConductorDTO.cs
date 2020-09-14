using System.Collections.Generic;

namespace DGT.DTOs
{
    public class ConductorDTO
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Puntos { get; set; }
        public List<InfoVehiculo> Vehiculos { get; set; }
    }
}
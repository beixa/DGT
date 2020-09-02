using System.ComponentModel.DataAnnotations;

namespace DGT.Models
{
    public class ConductorVehiculo
    {
        [Required]
        public string Dni { get; set; }
        public Conductor Conductor { get; set; }
        [Required]
        public string Matricula { get; set; }

        public Vehiculo Vehiculo { get; set; }
    }
}
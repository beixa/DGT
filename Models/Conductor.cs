using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DGT.Models
{
    public class Conductor
    {
        [Key]
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public int Puntos { get; set; } = 15;
        public IList<ConductorVehiculo> ConductorVehiculos { get; set; }
    }
}
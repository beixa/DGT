using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DGT.Models
{
    public class Vehiculo
    {
        [Key]
        [Required]
        public string Matricula { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        public IList<ConductorVehiculo> ConductorVehiculos { get; set; }
        public Infraccion Infraccion { get; set; }
    }
}
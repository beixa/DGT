using System.Collections.Generic;
using DGT.Models;

namespace DGT.DTOs
{
    public class VehiculoDTO
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public List<InfoConductor> Conductores { get; set; }
        public Infraccion Infraccion { get; set; }
    }
}
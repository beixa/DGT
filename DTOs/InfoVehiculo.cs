using DGT.Models;

namespace DGT.DTOs
{
    public class InfoVehiculo
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Infraccion Infraccion { get; set; }
    }
}
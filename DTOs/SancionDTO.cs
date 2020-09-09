using System;
using DGT.Models;

namespace DGT.DTOs
{
    public class SancionDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public InfoConductor Conductor { get; set; }
        public InfoVehiculo Vehiculo { get; set; }
    }
}
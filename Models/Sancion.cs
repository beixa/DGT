using System;

namespace DGT.Models
{
    public class Sancion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Conductor Conductor { get; set; }
        public Vehiculo Vehiculo { get; set; }

    }
}
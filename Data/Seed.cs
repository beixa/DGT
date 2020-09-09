using System.Collections.Generic;
using System.Linq;
using DGT.Models;

namespace DGT.Data
{
    public class Seed
    {
        public static void SeedData(DataContext ctx)
        {
            if(!ctx.Conductores.Any())
            {
                var conductores = new List<Conductor>
                {
                    new Conductor
                    {
                        Dni = "12345678A",
                        Nombre = "Manolo",
                        Apellidos = "García Fernandez"
                    },
                    new Conductor
                    {
                        Dni = "87654321Z",
                        Nombre = "María",
                        Apellidos = "Hernandez Díaz"
                    },
                    new Conductor
                    {
                        Dni = "12348765M",
                        Nombre = "Ernesto",
                        Apellidos = "Sevilla Suarez"
                    }
                };

                ctx.Conductores.AddRange(conductores);                
            }

            if(!ctx.Vehiculos.Any())
            {
                var vehiculos = new List<Vehiculo>
                {
                    new Vehiculo
                    {
                        Matricula = "1234BBB",
                        Marca = "Seat",
                        Modelo = "Ibiza"
                    },
                    new Vehiculo
                    {
                        Matricula = "4321ZZZ",
                        Marca = "Volvo",
                        Modelo = "S40"
                    },
                    new Vehiculo
                    {
                        Matricula = "1234CCC",
                        Marca = "Hyundai",
                        Modelo = "i30"
                    },
                    new Vehiculo
                    {
                        Matricula = "4321XXX",
                        Marca = "Mazda",
                        Modelo = "cx-3"
                    },
                    new Vehiculo
                    {
                        Matricula = "5678LLL",
                        Marca = "Audi",
                        Modelo = "a6"
                    },
                    new Vehiculo
                    {
                        Matricula = "3654JJJ",
                        Marca = "Ferrari",
                        Modelo = "F40"
                    },
                    new Vehiculo
                    {
                        Matricula = "8765KKK",
                        Marca = "Lamborghini",
                        Modelo = "Huracán"
                    },
                    new Vehiculo
                    {
                        Matricula = "2345DDD",
                        Marca = "Dacia",
                        Modelo = "Sandero"
                    },
                    new Vehiculo
                    {
                        Matricula = "6547HHH",
                        Marca = "Opel",
                        Modelo = "Corsa"
                    },
                    new Vehiculo
                    {
                        Matricula = "5871LMN",
                        Marca = "Ford",
                        Modelo = "Focus"
                    },
                    new Vehiculo
                    {
                        Matricula = "5672BBJ",
                        Marca = "Fiat",
                        Modelo = "500"
                    },
                };

                ctx.Vehiculos.AddRange(vehiculos);
            }

            if(!ctx.ConductorVehiculos.Any())
            {
                var conductorVehiculo = new List<ConductorVehiculo>
                {
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "1234BBB"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "87654321Z",
                        Matricula = "2345DDD"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12348765M",
                        Matricula = "1234BBB"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "2345DDD"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "4321ZZZ"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "1234CCC"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "4321XXX"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "5678LLL"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "3654JJJ"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "8765KKK"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "6547HHH"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "12345678A",
                        Matricula = "5672BBJ"
                    },
                    new ConductorVehiculo
                    {
                        Dni = "87654321Z",
                        Matricula = "5672BBJ"
                    },
                };

                ctx.ConductorVehiculos.AddRange(conductorVehiculo);
            }

            if(!ctx.Infracciones.Any())
            {
                var infracciones = new List<Infraccion>
                {
                    new Infraccion
                    {
                        Descripcion = "Sin cinturón",
                        DescuentoPuntos = 2
                    },
                    new Infraccion
                    {
                        Descripcion = "Uso telefono móvil",
                        DescuentoPuntos = 5
                    },
                    new Infraccion
                    {
                        Descripcion = "Conducir bajo los efectos del alcohol",
                        DescuentoPuntos = 8
                    },
                    new Infraccion
                    {
                        Descripcion = "Conduccion temeraria",
                        DescuentoPuntos = 6
                    }
                };

                ctx.Infracciones.AddRange(infracciones);
            }

            ctx.SaveChanges();            
        }
    }
}
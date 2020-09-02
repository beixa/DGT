using System.Collections.Generic;
using DGT.Data;
using DGT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/vehiculos")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IDGTRepo _repo;

        public VehiculosController(IDGTRepo repo)
        {
            _repo = repo;
        }

        //GET api/vehiculos
        [HttpGet]
        public ActionResult <IEnumerable<Vehiculo>> GetAllVehiculos()
        {
            var vehiculos = _repo.GetAllVehiculos();

            return Ok(vehiculos);
        }

        //GET api/vehiculos/{matricula}
        [HttpGet("{matricula}", Name = "GetVehiculoById")]
        public ActionResult<Vehiculo> GetVehiculoById (string matricula)
        {
            var vehiculo = _repo.GetVehiculoById(matricula);

            if(vehiculo != null)
            {
                return Ok(vehiculo);
            }
            return NotFound();
        }

        //POST api/vehiculos
        [HttpPost]
        public ActionResult<Conductor> CreateVehiculo (Vehiculo vehiculo)
        {           
            var vehiculoFromRepo = _repo.GetVehiculoById(vehiculo.Matricula);
            if (vehiculoFromRepo != null)
            {
                return BadRequest();
            }        
            _repo.CreateVehiculo(vehiculo);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetVehiculoById), new { matricula = vehiculo.Matricula}, vehiculo);
        }

        [HttpPost("{matricula}/{infraccionId}")]
        public ActionResult<Vehiculo> CreateInfraccionInVehiculo (string matricula, int infraccionId)
        {    
            var infraccionFromRepo = _repo.GetInfraccionById(infraccionId);
            var vehiculoFromRepo = _repo.GetVehiculoById(matricula);
            if (infraccionFromRepo == null || vehiculoFromRepo == null)
            {
                return BadRequest();
            }       
            _repo.CreateInfraccionInVehiculo(matricula, infraccionId);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetVehiculoById), new { matricula = matricula}, vehiculoFromRepo);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using DGT.Data;
using DGT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/habituales")]
    [ApiController]
    public class HabitualesController : ControllerBase
    {
         private readonly IDGTRepo _repo;

        public HabitualesController(IDGTRepo repo)
        {
            _repo = repo;
        }

        //GET api/habituales
        [HttpGet]
        public ActionResult <IEnumerable<ConductorVehiculo>> GetAllHabituales()
        {
            var habituales = _repo.GetAllHabituales();

            return Ok(habituales);
        }       

        //GET api/habituales/{dni}
        [HttpGet("{dni}")]
        public ActionResult <IEnumerable<ConductorVehiculo>> GetHabitualesByDni (string dni)
        {
            var habitual = _repo.GetHabitualesByDni(dni);

            if(habitual != null)
            {
                return Ok(habitual);
            }
            return NotFound();
        }

        //GET api/habituales/{dni}/{matricula}
        [HttpGet("{dni}/{matricula}", Name = "GetHabitualesByDniAndMatricula")]
        public ActionResult <ConductorVehiculo> GetHabitualesByDniAndMatricula (string dni, string matricula)
        {
            var habitual = _repo.GetHabitualByDniAndMatricula(dni,matricula);

            if(habitual != null)
            {
                return Ok(habitual);
            }
            return NotFound();
        }
        
        //POST api/habituales
        [HttpPost]
        public ActionResult<ConductorVehiculo> CreateHabitual (ConductorVehiculo habitual)
        {  
            var conductor = _repo.GetConductorById(habitual.Dni);
            var vehiculo = _repo.GetVehiculoById(habitual.Matricula);
            var habitualesConductor = _repo.GetHabitualesByDni(habitual.Dni);

            if (habitualesConductor.Count() >= 10 || conductor == null || vehiculo == null)
            {
                return BadRequest();
            }        
            _repo.CreateHabitual(habitual);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetHabitualesByDniAndMatricula), new { dni = habitual.Dni, matricula = habitual.Matricula}, habitual);
        }
    }
}
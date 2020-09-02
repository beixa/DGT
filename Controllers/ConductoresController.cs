using System.Collections.Generic;
using DGT.Data;
using DGT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/conductores")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {
        private readonly IDGTRepo _repo;

        public ConductoresController(IDGTRepo repo)
        {
            _repo = repo;
        }

        //GET api/conductores
        [HttpGet]
        public ActionResult <IEnumerable<Conductor>> GetAllConductores()
        {
            var conductores = _repo.GetAllConductores();

            return Ok(conductores);
        }

        //GET api/conductores/{dni}
        [HttpGet("{dni}", Name = "GetConductorById")]
        public ActionResult<Conductor> GetConductorById (string dni)
        {
            var conductor = _repo.GetConductorById(dni);

            if(conductor != null)
            {
                return Ok(conductor);
            }
            return NotFound();
        }

        //GET api/conductores/top/{N}
        [HttpGet("top/{N}")]
        public ActionResult<Conductor> GetNConductores (int N)
        {
            var conductores = _repo.GetNConductores(N);

            return Ok(conductores);
        }

        //POST api/conductores
        [HttpPost]
        public ActionResult<Conductor> CreateConductor (Conductor conductor)
        {    
            var conductorFromRepo = _repo.GetConductorById(conductor.Dni);
            if (conductorFromRepo != null)
            {
                return BadRequest();
            }        
            _repo.CreateConductor(conductor);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetConductorById), new { dni = conductor.Dni}, conductor);
        }
    }
}
using System.Collections.Generic;
using DGT.Data;
using DGT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/infracciones")]
    [ApiController]
    public class InfraccionesController : ControllerBase
    {
        private readonly IDGTRepo _repo;

        public InfraccionesController(IDGTRepo repo)
        {
            _repo = repo;
        }

        //GET api/infracciones
        [HttpGet]
        public ActionResult <IEnumerable<Infraccion>> GetAllInfracciones()
        {
            var infracciones = _repo.GetAllInfracciones();

            return Ok(infracciones);
        }

        //GET api/infracciones/{id}
        [HttpGet("{id}", Name = "GetInfraccionById")]
        public ActionResult<Conductor> GetInfraccionById (int id)
        {
            var infraccion = _repo.GetInfraccionById(id);

            if(infraccion != null)
            {
                return Ok(infraccion);
            }
            return NotFound();
        }

        //POST api/infracciones
        [HttpPost]
        public ActionResult<Conductor> CreateInfraccion (Infraccion infraccion)
        {    
            var infraccionFromRepo = _repo.GetInfraccionById(infraccion.Id);
            if (infraccionFromRepo != null)
            {
                return BadRequest();
            }        
            _repo.CreateInfraccion(infraccion);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetInfraccionById), new { id = infraccion.Id}, infraccion);
        }
    }
}
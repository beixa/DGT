using System.Collections.Generic;
using DGT.Data;
using DGT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/sanciones")]
    [ApiController]
    public class sancionesController : ControllerBase
    {
        private readonly IDGTRepo _repo;

        public sancionesController(IDGTRepo repo)
        {
            _repo = repo;
        }

        //GET api/sanciones
        [HttpGet]
        public ActionResult <IEnumerable<Sancion>> GetAllSanciones()
        {
            var conductores = _repo.GetAllSanciones();

            return Ok(conductores);
        }

        //GET api/sanciones/{id}
        [HttpGet("{dni}")]
        public ActionResult<IEnumerable<Sancion>> GetSancionesByDni (string dni)
        {
            var sanciones = _repo.GetSancionesByDni(dni);

            if(sanciones != null)
            {
                return Ok(sanciones);
            }
            return NotFound();
        }

        //GET api/sanciones/habituales/{cnt}
        [HttpGet("habituales/{cnt}")]
        public ActionResult<IEnumerable<string>> GetSancionesHabituales (int cnt)
        {
            var sanciones = _repo.GetSancionesHabituales(cnt);

            if(sanciones != null)
            {
                return Ok(sanciones);
            }
            return NotFound();
        }
    }
}
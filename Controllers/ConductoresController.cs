using System.Collections.Generic;
using AutoMapper;
using DGT.Data;
using DGT.DTOs;
using DGT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/conductores")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {
        private readonly IConductorRepo _repo;
        private readonly IMapper _mapper;

        public ConductoresController(IConductorRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/conductores
        [HttpGet]
        public ActionResult <IEnumerable<ConductorDTO>> GetAllConductores()
        {
            var conductores = _repo.GetAllConductores();

            return Ok(_mapper.Map<IEnumerable<ConductorDTO>>(conductores));
        }

        //GET api/conductores/{dni}
        [HttpGet("{dni}", Name = "GetConductorById")]
        public ActionResult<ConductorDTO> GetConductorById (string dni)
        {
            var conductor = _repo.GetConductorById(dni);

            if(conductor != null)
            {
                return Ok(_mapper.Map<ConductorDTO>(conductor));
            }
            return NotFound();
        }

        //GET api/conductores/top/{N}
        [HttpGet("top/{N}")]
        public ActionResult<IEnumerable<ConductorDTO>> GetNConductores (int N)
        {
            var conductores = _repo.GetNConductores(N);

            return Ok(_mapper.Map<IEnumerable<ConductorDTO>>(conductores));
        }

        //POST api/conductores
        [HttpPost]
        public ActionResult<ConductorDTO> CreateConductor (Conductor conductor)
        {    
            var conductorFromRepo = _repo.GetConductorById(conductor.Dni);
            if (conductorFromRepo != null)
            {
                return BadRequest();
            }        
            _repo.CreateConductor(conductor);
            _repo.SaveChanges();

            var conductorDTO = _mapper.Map<ConductorDTO>(conductor);

            return CreatedAtRoute(nameof(GetConductorById), new { dni = conductorDTO.Dni}, conductorDTO);
        }
    }
}
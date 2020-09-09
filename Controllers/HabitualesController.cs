using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DGT.Data;
using DGT.DTOs;
using DGT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/habituales")]
    [ApiController]
    public class HabitualesController : ControllerBase
    {
         private readonly IDGTRepo _repo;
        private readonly IMapper _mapper;

        public HabitualesController(IDGTRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/habituales
        [HttpGet]
        public ActionResult <IEnumerable<HabitualDTO>> GetAllHabituales()
        {
            var habituales = _repo.GetAllHabituales();

            return Ok(_mapper.Map<IEnumerable<HabitualDTO>>(habituales));
        }       

        //GET api/habituales/{dni}
        [HttpGet("{dni}")]
        public ActionResult <IEnumerable<HabitualDTO>> GetHabitualesByDni (string dni)
        {
            var habituales = _repo.GetHabitualesByDni(dni);

            if(habituales != null)
            {
                return Ok(_mapper.Map<IEnumerable<HabitualDTO>>(habituales));
            }
            return NotFound();
        }

        //GET api/habituales/{dni}/{matricula}
        [HttpGet("{dni}/{matricula}", Name = "GetHabitualesByDniAndMatricula")]
        public ActionResult <HabitualDTO> GetHabitualesByDniAndMatricula (string dni, string matricula)
        {
            var habitual = _repo.GetHabitualByDniAndMatricula(dni,matricula);

            if(habitual != null)
            {
                return Ok(_mapper.Map<HabitualDTO>(habitual));
            }
            return NotFound();
        }
        
        //POST api/habituales
        [HttpPost]
        public ActionResult<HabitualDTO> CreateHabitual (ConductorVehiculo habitual)
        {  
            var conductor = _repo.GetConductorById(habitual.Dni);
            var vehiculo = _repo.GetVehiculoById(habitual.Matricula);
            var habitualesConductor = _repo.GetHabitualesByDni(habitual.Dni);
            var habituales = _repo.GetHabitualByDniAndMatricula(habitual.Dni, habitual.Matricula);

            if (habitualesConductor.Count() >= 10 || conductor == null || vehiculo == null || habituales != null)
            {
                return BadRequest();
            }     
            _repo.CreateHabitual(habitual);
            _repo.SaveChanges();

            var habitualDTO = _mapper.Map<HabitualDTO>(habitual);

            return CreatedAtRoute(nameof(GetHabitualesByDniAndMatricula), new { dni = habitualDTO.Dni, matricula = habitualDTO.Matricula}, habitualDTO);
        }
    }
}
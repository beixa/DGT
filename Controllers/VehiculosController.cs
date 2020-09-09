using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DGT.Data;
using DGT.DTOs;
using DGT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/vehiculos")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IDGTRepo _repo;
        private readonly IMapper _mapper;

        public VehiculosController(IDGTRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/vehiculos
        [HttpGet]
        public ActionResult <IEnumerable<VehiculoDTO>> GetAllVehiculos()
        {
            var vehiculos = _repo.GetAllVehiculos();

            return Ok(_mapper.Map<IEnumerable<VehiculoDTO>>(vehiculos));
        }

        //GET api/vehiculos/{matricula}
        [HttpGet("{matricula}", Name = "GetVehiculoById")]
        public ActionResult<VehiculoDTO> GetVehiculoById (string matricula)
        {
            var vehiculo = _repo.GetVehiculoById(matricula);

            if(vehiculo != null)
            {
                return Ok(_mapper.Map<VehiculoDTO>(vehiculo));
            }
            return NotFound();
        }

        //POST api/vehiculos
        [HttpPost]
        public ActionResult<VehiculoDTO> CreateVehiculo (Vehiculo vehiculo)
        {           
            var vehiculoFromRepo = _repo.GetVehiculoById(vehiculo.Matricula);
            if (vehiculoFromRepo != null)
            {
                return BadRequest();
            }        
            _repo.CreateVehiculo(vehiculo);
            _repo.SaveChanges();

            var vehiculoDTO = _mapper.Map<VehiculoDTO>(vehiculo);

            return CreatedAtRoute(nameof(GetVehiculoById), new { matricula = vehiculoDTO.Matricula}, vehiculoDTO);
        }

        [HttpPost("{matricula}/{infraccionId}")]
        public ActionResult<VehiculoDTO> CreateInfraccionInVehiculo (string matricula, int infraccionId)
        {    
            var infraccionFromRepo = _repo.GetInfraccionById(infraccionId);
            var vehiculoFromRepo = _repo.GetVehiculoById(matricula);
            var habitualesFromRepo = _repo.GetAllHabituales();
            
            if (infraccionFromRepo == null || vehiculoFromRepo == null || !habitualesFromRepo.Any(x => x.Matricula == matricula))
            {
                return BadRequest();
            }   

            _repo.CreateInfraccionInVehiculo(matricula, infraccionId);
            _repo.SaveChanges();

            var vehiculoDTO = _mapper.Map<VehiculoDTO>(vehiculoFromRepo);

            return CreatedAtRoute(nameof(GetVehiculoById), new { matricula = matricula}, vehiculoDTO);
        }
    }
}
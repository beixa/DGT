using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DGT.Data;
using DGT.Data.Repositories;
using DGT.DTOs;
using DGT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/vehiculos")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoRepo _repo;
        private readonly IMapper _mapper;
        private readonly IInfraccionRepo _infraccionRepo;
        private readonly IHabitualesRepo _habitualRepo;

        public VehiculosController(IVehiculoRepo repo, IInfraccionRepo infraccionRepo, IHabitualesRepo habitualRepo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _infraccionRepo = infraccionRepo;
            _habitualRepo = habitualRepo;
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
            var infraccion = _infraccionRepo.GetInfraccionById(infraccionId);
            var vehiculo = _repo.GetVehiculoById(matricula);
            var habituales = _habitualRepo.GetAllHabituales();
            
            if (infraccion == null || vehiculo == null || !habituales.Any(x => x.Matricula == matricula))
            {
                return BadRequest();
            }   

            _repo.CreateInfraccionInVehiculo(vehiculo, infraccion, habituales);
            _repo.SaveChanges();

            var vehiculoDTO = _mapper.Map<VehiculoDTO>(vehiculo);

            return CreatedAtRoute(nameof(GetVehiculoById), new { matricula = matricula}, vehiculoDTO);
        }
    }
}
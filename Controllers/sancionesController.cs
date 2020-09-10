using System.Collections.Generic;
using AutoMapper;
using DGT.Data.Repositories;
using DGT.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DGT.Controllers
{
    [Route("api/sanciones")]
    [ApiController]
    public class sancionesController : ControllerBase
    {
        private readonly ISancionRepo _repo;
        private readonly IMapper _mapper;

        public sancionesController(ISancionRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/sanciones
        [HttpGet]
        public ActionResult <IEnumerable<SancionDTO>> GetAllSanciones()
        {
            var sanciones = _repo.GetAllSanciones();

            return Ok(_mapper.Map<IEnumerable<SancionDTO>>(sanciones));
        }

        //GET api/sanciones/{id}
        [HttpGet("{dni}")]
        public ActionResult<IEnumerable<SancionDTO>> GetSancionesByDni (string dni)
        {
            var sanciones = _repo.GetSancionesByDni(dni);

            if(sanciones != null)
            {
                return Ok(_mapper.Map<IEnumerable<SancionDTO>>(sanciones));
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
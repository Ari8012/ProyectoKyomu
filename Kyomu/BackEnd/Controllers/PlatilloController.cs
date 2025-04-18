﻿using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PlatilloController : ControllerBase
    {
        IPlatilloService _platilloService;
        public PlatilloController(IPlatilloService platilloService)
        {
            _platilloService = platilloService;
        }

        // GET: api/<PlatilloController>
        [HttpGet]
        public IEnumerable<PlatilloDTO> Get()
        {
            return _platilloService.GetPlatillos();
        }

        // GET api/<PlatilloController>/5
        [HttpGet("{id}")]
        public PlatilloDTO Get(int id)
        {
            return _platilloService.GetPlatilloById(id);
        }

        // POST api/<PlatilloController>
        [HttpPost]
        public void Post([FromBody] PlatilloDTO platillo)
        {
            _platilloService.Add(platillo);
        }

        // PUT api/<PlatilloController>/5
        [HttpPut("{id}")]
        public ActionResult<PlatilloDTO> Put([FromBody] PlatilloDTO platillo)
        {
            _platilloService.Update(platillo);
            //Devolver el objeto actualizado que solicita el front//
            return Ok(platillo);
        }

        // DELETE api/<PlatilloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _platilloService.Delete(id);
        }
    }
}

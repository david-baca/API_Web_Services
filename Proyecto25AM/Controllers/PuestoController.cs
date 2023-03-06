﻿using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using David_Stephen.Services.Iservices;
using David_Stephen.Services.IServices;
using David_Stephen.Services.Services;

namespace David_Stephen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuestoController : Controller
    {
        private readonly IPuestoServices _puestoServices;
        public PuestoController(IPuestoServices puestoServices)
        {
            _puestoServices = puestoServices;
        }
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PuestoResponse i)
        {
            return Ok(await _puestoServices.CrearPuestos(i));
        }
        [HttpGet]
        public async Task<IActionResult> GetPuesto()
        {
            return Ok(await _puestoServices.GetPuesto());
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _puestoServices.EliminarPuesto(id));
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarPuesto([FromBody] PuestoResponse i, int id)
        {
            return Ok(await _puestoServices.ActualizarPuesto(i, id));
        }
        [HttpGet("{id}")]
        public ActionResult ObtenerPuestoID(int id)
        {
            return Ok(_puestoServices.ObtenerPuestoId(id));
        }
    }
}

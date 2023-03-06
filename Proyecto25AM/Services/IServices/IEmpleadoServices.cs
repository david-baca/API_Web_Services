using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace David_Stephen.Services.Iservices
{
    public interface IEmpleadoServices
    {
        public Task<Response<List<Empleado>>> GetEmpleados();
        public Task<Response<Empleado>> CrearEmpleado(EmpleadoResponse request);
        public Task<Response<Empleado>> ActualizarEmpleado([FromBody] EmpleadoResponse i, int id);
        public Task<Response<Empleado>> EliminarEmpleado(int id);
        public ActionResult<Response<Empleado>> ObtenerEmpleadoId(int id);
    }
}

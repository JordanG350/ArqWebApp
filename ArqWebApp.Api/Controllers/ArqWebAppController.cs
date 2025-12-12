using ArqWebApp.Core.Crud.Interfaces;
using ArqWebApp.Core.Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArqWebApp.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class ArqWebAppController : ControllerBase
    {
        private readonly IArqWebAppCrud _service;

        public ArqWebAppController(IArqWebAppCrud service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetAllCars")]
        public async Task<IActionResult> GetAllCars()
            => Ok(await _service.GetAllCars());

        [HttpGet(Name = "GetCarById")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var result = await _service.GetCarById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost(Name = "CreateCar")]
        public async Task<IActionResult> CreateCar([FromBody] Cars car)
            => Ok(await _service.CreateCar(car));

        [HttpPut(Name = "UpdateCar")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Cars car)
        {
            var result = await _service.UpdateCar(id, car);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete(Name = "DeleteCar")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var ok = await _service.DeleteCar(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}

using ArqWebApp.Api.Models;
using ArqWebApp.Core.Crud.Interfaces;
using ArqWebApp.Core.Crud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpGet(Name = "GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
            => Ok(await _service.GetAllProduct());

        [HttpGet(Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _service.GetProductById(id);
            if (result == null) 
            {
                ErrorDetails details = new ErrorDetails();
                details.StatusCode = (int) HttpStatusCode.NotFound;
                details.Message = "Producto no encontrado";

                return NotFound(details);
            } 
            return Ok(result);
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] Product car)
            => Ok(await _service.CreateProduct(car));

        [HttpPut(Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product car)
        {
            var result = await _service.UpdateProduct(id, car);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete(Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var ok = await _service.DeleteProduct(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}

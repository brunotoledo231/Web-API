using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProgII.Models;

namespace WebApiProgII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController : ControllerBase
    {
        //un metodo que me devuelve una respuesta http
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(new Fecha());
        }
    }
}

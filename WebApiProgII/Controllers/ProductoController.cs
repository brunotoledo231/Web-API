using Microsoft.AspNetCore.Mvc;
using WebApiProgII.Interfaces;
using WebApiProgII.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProgII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase,IAplicacion
    {
        private static readonly List<Producto> listProducto = new List<Producto>();
        // GET: api/<ProductoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listProducto);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public IActionResult Post(Producto p)
        {
            if (p.Codigo == null && p.NombreProd == "" && p.Precio == 0)
            {
                return BadRequest("Debe llenar todos los campos del producto ");
            }
            listProducto.Add(p);
            return Ok(listProducto);
        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public IActionResult Put(Producto p)
        {
            foreach(Producto prod in listProducto)
            {
                if(prod.Codigo.Equals(p.Codigo))
                {
                    prod.Codigo = p.Codigo;
                    prod.NombreProd = p.NombreProd;
                    prod.Precio = p.Precio;
                    return Ok(p);
                }
            }
            return BadRequest("No se localizo el producto");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete]
        public IActionResult Delete(Producto p)
        {
            foreach (Producto prod in listProducto)
            {
                if (prod.Codigo.Equals(p.Codigo))
                {
                    listProducto.Remove(prod);
                    return Ok("se elimino el producto");
                }
            }
            return BadRequest("No se elimino el producto");
        }








    }
}

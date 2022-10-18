using Microsoft.AspNetCore.Mvc;
using WebApiProgII.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProgII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private static readonly List<Moneda> lst=new List<Moneda>();//para que se cree una sola vez.Hacer un sigleton que sirva para almacenar objetos moneda.
        //readonly es un atributo constante. no cambia mas la referencia en memoria. es de solo lectura.
        //public MonedaController()//constructor para inicializar este atributo de esta clase 
        //{
        //    //lst = new List<Moneda>();     
        //}
        // GET: api/Moneda
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lst);
        }

        // GET api/Moneda/Dolar
        [HttpGet("{nombreMoneda}")]//denotar posicionalmente parametros que vienen de la URL
        public IActionResult Get(string nombreMoneda)
        {
            foreach(Moneda x in lst)
            {
                if(x.Nombre.Equals(nombreMoneda))
                {
                    return Ok(x);
                }
            }
            return NotFound("Moneda no registrada!");//devuelve un 404
        }

        // POST api/<MonedaController>
        [HttpPost]
        public IActionResult Post([FromBody] Moneda m)//para obtener y enviar info a un servidor web.cada vez que hago post creo un recurso del lado dela API rest 
        {
            if(m == null || string.IsNullOrEmpty(m.Nombre)) //si es nulo o con nombre vacio
            {
                return BadRequest("error objeto incorrecto"); //permite devolver un 400
            }
            lst.Add(m);
            return Ok(m);
        }

        // PUT api/<MonedaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MonedaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

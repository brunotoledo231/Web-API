using Microsoft.AspNetCore.Mvc;
using WebApiProgII.Interfaces;
using WebApiProgII.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProgII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        private static  List<Temperatura> registroTemp=new List<Temperatura>();
        public static List<Temperatura>  ObtenerRegistro()
        {
            if (registroTemp == null)
            {
                registroTemp = new List<Temperatura>();
            }
            return registroTemp;
        }
       
        

        
        // GET: api/<TemperaturaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(registroTemp);//devuelve 200
        }

        // GET api/<TemperaturaController>/5
        [HttpGet("{identificador}")]
        public IActionResult Get(int indentificador)
        {
            foreach(Temperatura iden in registroTemp)
            {
                if(iden.Identificador.Equals(indentificador))
                {
                    return Ok(iden);
                }
            }
            return NotFound("No se encontro el identificador de temperatura");//devuelve error 404
        }

        // POST api/<TemperaturaController>
        [HttpPost]
        public IActionResult Post([FromBody] Temperatura t)
        { 
            if(t == null||string.IsNullOrEmpty(t.Identificador.ToString()))
            {
                return BadRequest("el identificador no es valido");
            }
            if(Existe(t))
            {
                return BadRequest("el identificador ya pertenece a la lista");
            }
            registroTemp.Add(t);
            
            return Ok(t);
            
        }

        private bool Existe(Temperatura nuevoRegistro)
        {
            bool existe = false;
            
            foreach (Temperatura t in registroTemp)
            {
                if(nuevoRegistro.Identificador.Equals(t.Identificador))
                    existe = true;
                
            }
            
            return existe;
        }

        // PUT api/<TemperaturaController>/5
        [HttpPut]
        public IActionResult Put( Temperatura t)
        { 
            //if (Existe(t)==true)
            //{
            //    registroTemp.Remove(t);
            //    registroTemp.Add(t);
            //    return Ok(t);
            //}
            //else return NotFound();
            foreach(Temperatura temp in registroTemp)
            {
                if (temp.Identificador == t.Identificador)
                {
                    temp.FechaHora = t.FechaHora;
                    temp.Valor = t.Valor;
                    return Ok(t);
                }
            }
            return NotFound();
            
        }

        // DELETE api/<TemperaturaController>/5
        [HttpDelete("{identificador}")]
        public IActionResult Delete(int t)
        {
            //if (!Existe(t))
            //{
            //    registroTemp.Remove(t);
            //    return Ok("Se borro exitosamente el registro");
            //}
            //else return NotFound();
            foreach(Temperatura temp in registroTemp)
            {
                if(temp.Identificador==t)
                {
                    registroTemp.Remove(temp);
                    return Ok("Se elimino el registro");
                }
            }
            return NotFound();
            
        }

        
    }
}

using Microsoft.AspNetCore.Routing.Constraints;

namespace WebApiProgII.Models
{
    public class Temperatura
    {
        public int Identificador { get; set; }
        public DateTime FechaHora { get; set; }
        public float Valor { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApiProgII.Models;

namespace WebApiProgII.Interfaces
{
    public interface IAplicacion
    {
        public IActionResult Get();
        public IActionResult Post(Producto p);
        public IActionResult Put(Producto p);
        public IActionResult Delete (Producto p);

    }
}

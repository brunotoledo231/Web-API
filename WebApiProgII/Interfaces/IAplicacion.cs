using WebApiProgII.Models;

namespace WebApiProgII.Interfaces
{
    public interface IAplicacion
    {
        List<Producto> ConsultarProductos();
        List<Producto> AgregarProductos();
        List<Producto> ActualizarProductos();
        List<Producto> EliminarProductos();

    }
}

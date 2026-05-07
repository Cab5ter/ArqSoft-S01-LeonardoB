using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    public class RentaController : Controller
    {
        private static List<Renta> _rentas = new List<Renta>()
        {
            new Renta
            {
                Id = 1,
                VideojuegoId = 1,
                ClienteId = 1,
                FechaRenta = new DateTime(2025, 4, 1),
                FechaDevolucion = new DateTime(2025, 4, 5),
                Devuelta = true
            }
        };

        public IActionResult Index()
        {
            ViewBag.Videojuegos = CatalogoController._items;
            ViewBag.Clientes = ClienteController._clientes;
            return View(_rentas);
        }

        public IActionResult Agregar()
        {
            ViewBag.Videojuegos = CatalogoController._items;
            ViewBag.Clientes = ClienteController._clientes;
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Renta renta)
        {
            renta.Id = _rentas.Count + 1;
            _rentas.Add(renta);

            var videojuego = CatalogoController._items.FirstOrDefault(v => v.Id == renta.VideojuegoId);
            if (videojuego != null)
                videojuego.Disponible = false;

            return RedirectToAction("Index");
        }
    }
}

using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    public class ClienteController : Controller
    {
        private static List<Cliente> _clientes = new List<Cliente>()
        {
            new Cliente { Id = 1, Nombre = "Juan Pérez", Email = "juan@email.com", Telefono = "555-1234" },
            new Cliente { Id = 2, Nombre = "María López", Email = "maria@email.com", Telefono = "555-5678" }
        };

        public IActionResult Index()
        {
            return View(_clientes);
        }

        public IActionResult Detalle(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            return cliente == null ? NotFound() : View(cliente);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Cliente cliente)
        {
            cliente.Id = _clientes.Count + 1;
            _clientes.Add(cliente);
            return RedirectToAction("Index");
        }
    }
}

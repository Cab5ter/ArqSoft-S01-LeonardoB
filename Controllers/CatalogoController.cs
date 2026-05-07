//using System.Collections.Generic;
//using System.Linq;
using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        private static List<Item> _items = new List<Item>()
        {
            new Item {
                Id = 1,
                Titulo = "Devil May Cry",
                Genero = "Hack and Slash",
                Ano = 2001,
                Consola = "PlayStation 2",
                Descripcion = "Videojuego que trata de un cazador de demonios llamado Dante."
            }, 
            new Item
            {
                Id = 2,
                Titulo = "Castlevania: Symphony of the Night",
                Genero = "Metroidvania",
                Ano = 1997,
                Consola = "PlayStation 2",
                Descripcion = "Alucard explora el castillo de su padre para destruirlo."
            },
            new Item 
            { 
                Id = 3, 
                Titulo = "NieR: Automata", 
                Genero = "Action RPG", 
                Ano = 2017, 
                Consola = "PS4/PC", 
                Descripcion = "La batalla de los androides por el futuro de la humanidad." 
            }
        };
        
        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero)
                ? _items
                : _items.Where(i => i.Genero == genero).ToList();

            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;
            
            return View(resultado);
        }
        
        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null ? NotFound() : View(item);
        } 
        
        public IActionResult Agregar()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            
            return RedirectToAction("Index");
        }
    }
}
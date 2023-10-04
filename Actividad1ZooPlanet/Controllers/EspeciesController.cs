using Actividad1ZooPlanet.Models.Entities;
using Actividad1ZooPlanet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad1ZooPlanet.Controllers
{
    public class EspeciesController : Controller
    {
        public IActionResult Index(string Id)
        {
            AnimalesContext context = new();
            var clase = context.Clase.Where(x=> x.Nombre == Id).FirstOrDefault();
            if (clase == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var datos = context.Especies.OrderBy(x => x.Especie).Where(x => x.IdClase == clase.Id).Select(x => new EspecieModel
                {
                    Id = x.Id,
                    Nombre = x.Especie ?? ""
                });
                IndexEspeciesViewModel vm = new()
                {
                    Id = clase.Id,
                    Especie = Id,
                    ListaEspecies = datos
                };
                return View(vm);
            }
        }

        public IActionResult Detalles(string Id)
        {
            AnimalesContext context = new();
            var datos = context.Especies.Include(x=> x.IdClaseNavigation).FirstOrDefault(x=> x.Especie == Id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                DetallesViewModel vm = new()
                {
                    Id = datos.Id,
                    Nombre = datos.Especie,
                    Clase = datos.IdClaseNavigation?.Nombre ?? "N/A",
                    Peso = datos.Peso,
                    Tamaño = datos.Tamaño,
                    Habitat = datos.Habitat ?? "N/A",
                    Descripcion = datos.Observaciones ?? "N/A"
                };
                return View(vm);
            }
        }
    }
}

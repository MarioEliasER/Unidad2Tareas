using Actividad1ZooPlanet.Models.Entities;
using Actividad1ZooPlanet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Actividad1ZooPlanet.Controllers
{
    public class EspeciesController : Controller
    {
        public IActionResult Index(string Id)
        {
            AnimalesContext context = new AnimalesContext();
            var clase = context.Clase.Where(x=> x.Nombre == Id).FirstOrDefault();
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
}

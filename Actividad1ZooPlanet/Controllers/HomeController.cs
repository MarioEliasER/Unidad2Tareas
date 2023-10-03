using Actividad1ZooPlanet.Models.Entities;
using Actividad1ZooPlanet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Actividad1ZooPlanet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AnimalesContext context = new AnimalesContext();
            var datos = context.Clase.OrderBy(x => x.Nombre)
                .Select(x => new IndexClaseViewModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre??"",
                    Descripcion = x.Descripcion??""
                });
            return View(datos);
        }
    }
}

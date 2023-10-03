namespace Actividad1ZooPlanet.Models.ViewModels
{
    public class IndexEspeciesViewModel
    {
        public int Id { get; set; }
        public string Especie { get; set; } = null!;
        public IEnumerable<EspecieModel> ListaEspecies { get; set; } = null!;
    }

    public class EspecieModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}

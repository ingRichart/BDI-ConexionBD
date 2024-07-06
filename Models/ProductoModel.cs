using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConexionEF.Models
{
    public class ProductoModel
    {
        public ProductoModel()
        {
        }
        
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public Guid MarcaModelId { get; set; }

        public MarcaModel? MarcaModel { get; set; }

        public List<SelectListItem>? ListadoMarcas { get; set; }

        public Guid TipoModelId { get; set; }

        public TipoModel? TipoModel { get; set; }

        public List<SelectListItem>? ListadoTipos { get; set; }

        public string? TipoModelNombre { get; set; }

        public string? MarcaModelNombre { get; set; }
    }
}
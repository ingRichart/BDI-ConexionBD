namespace ConexionEF.Entities
{
    public class TipoProducto
    {
        public TipoProducto()
        {
        }

        public Guid Id { get; set; }
        
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
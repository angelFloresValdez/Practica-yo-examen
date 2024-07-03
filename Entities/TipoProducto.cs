
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

        public bool Activo { get; set; }
        
        public List<Producto> Productos { get; set; }
        
        
        
    }
}
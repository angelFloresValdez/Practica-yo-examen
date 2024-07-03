namespace ConexionEF.Entities
{
    public class Producto
    {
        public Producto()
        {
        }


        public Guid Id { get; set; }

        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }

        public MarcaProducto MarcaProducto { get; set; }

        public Guid MarcaProductoId { get; set; }

        public TipoProducto TipoProducto { get; set; }

        public Guid TipoProductoId { get; set; }
        
        
        
        
        
        
        
        
        
        
        
        
    }
}
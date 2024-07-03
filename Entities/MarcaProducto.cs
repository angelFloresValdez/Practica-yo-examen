using System.ComponentModel.DataAnnotations;

namespace ConexionEF.Entities
{
    public class MarcaProducto
    {
        public MarcaProducto()
        {
        }

        public Guid Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }
        
        public List<Producto> Productos { get; set; }
        
        
        

    }
}
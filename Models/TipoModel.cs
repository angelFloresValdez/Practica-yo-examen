namespace ConexionEF.Models
{
    public class TipoModel
    {
        public TipoModel()
        {
        }
        
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
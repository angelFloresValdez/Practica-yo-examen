namespace ConexionEF.Models
{
    public class MarcaModel
    {
        public MarcaModel()
        {
        }
        
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
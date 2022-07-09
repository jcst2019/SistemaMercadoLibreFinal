namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Categoria
    {
        private int id;
        private String nombre;
        private String descripcion;
        private bool activo;

        public Categoria()
        {

        }
        public Categoria(int id, String nombre, String descripcion, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.activo = activo;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

        public bool getActivo()
        {
            return activo;
        }

        public void setActivo(bool activo)
        {
            this.activo = activo;
        }

    }
}

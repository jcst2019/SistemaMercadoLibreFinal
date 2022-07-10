namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Categoria
    {
        private String id;
        private String nombre;
        private String descripcion;
        private String estado;

        public Categoria()
        {

        }
        public Categoria(String id, String nombre, String descripcion, String estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.estado = estado;
        }

        public String getId()
        {
            return id;
        }

        public void setId(String id)
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

        public String getEstado()
        {
            return estado;
        }

        public void setEstado(String estado)
        {
            this.estado = estado;
        }

    }
}

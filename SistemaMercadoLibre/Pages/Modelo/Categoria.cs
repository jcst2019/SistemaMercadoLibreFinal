namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Categoria
    {
        private String id;
        private String descripcion;
        private String estado;
        private String usuarioRegistro;
        private String fechaRegistro;

        public Categoria()
        {

        }
        public Categoria(String id, String descripcion, String estado, String usuarioRegistro, String fechaRegistro)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.estado = estado;
            this.usuarioRegistro = usuarioRegistro;
            this.fechaRegistro = fechaRegistro;
        }

        public String getId()
        {
            return id;
        }

        public void setId(String id)
        {
            this.id = id;
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

        public String getUsuarioRegistro()
        {
            return usuarioRegistro;
        }

        public void setUsuarioRegistro(String usuarioRegistro)
        {
            this.usuarioRegistro = usuarioRegistro;
        }

        public String getFechaRegistro()
        {
            return fechaRegistro;
        }

        public void setFechaRegistro(String fechaRegistro)
        {
            this.fechaRegistro = fechaRegistro;
        }

    }
}

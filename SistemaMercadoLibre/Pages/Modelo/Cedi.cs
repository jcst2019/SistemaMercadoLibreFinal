namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Cedi
    {
        private String id;
        private String nombre;
        private String ubicacion;
        private String direccion;
        private String ciudad;

        public Cedi()
        {

        }

        public Cedi(String id, String nombre, String ubicacion, String direccion, String ciudad)
        {
            this.id = id;
            this.nombre = nombre;
            this.ubicacion = ubicacion;
            this.direccion = direccion; 
            this.ciudad = ciudad;   
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

        public String getUbicacion()
        {
            return ubicacion;
        }

        public void setUbicacion(String ubicacion)
        {
            this.ubicacion = ubicacion;
        }

        public String getDireccion()
        {
            return direccion;
        }

        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }

        public String getCiudad()
        {
            return ciudad;
        }

        public void setCiudad(String ciudad)
        {
            this.ciudad = ciudad;
        }



        // public String id { get; set; }
    }
}

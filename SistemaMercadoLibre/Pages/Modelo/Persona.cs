namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Persona
    {
        private String idPersona;
        private String nombres;
        private String apellidos;
        private int codigoDocumento;
        private String numeroDocumento;
        private String correo;
        private String usuarioRegistro;
        private String fechaRegistro;

        public Persona()
        {
        }
    
        public Persona(String idPersona, String nombres, String apellidos, int codigoDocumento, String numeroDocumento, String correo, String usuarioRegistro, String fechaRegistro)
        {
            this.idPersona = idPersona;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.codigoDocumento = codigoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.correo = correo;
            this.usuarioRegistro = usuarioRegistro;
            this.fechaRegistro = fechaRegistro;
        }

        public String getIdPersona()
        {
            return idPersona;
        }

        public void setIdPersona(String idPersona)
        {
            this.idPersona = idPersona;
        }

        public String getNombres()
        {
            return nombres;
        }

        public void setNombres(String nombres)
        {
            this.nombres = nombres;
        }

        public String getApellidos()
        {
            return apellidos;
        }

        public void setApellidos(String apellidos)
        {
            this.apellidos = apellidos;
        }

        public int getCodigoDocumento()
        {
            return codigoDocumento;
        }

        public void setCodigoDocumento(int codigoDocumento)
        {
            this.codigoDocumento = codigoDocumento;
        }

        public String getNumeroDocumento()
        {
            return numeroDocumento;
        }

        public void setNumeroDocumento(String numeroDocumento)
        {
            this.numeroDocumento = numeroDocumento;
        }

        public String getCorreo()
        {
            return correo;
        }

        public void setCorreo(String correo)
        {
            this.correo = correo;
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

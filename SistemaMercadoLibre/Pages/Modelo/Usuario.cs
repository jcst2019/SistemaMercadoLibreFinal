namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Usuario : Persona
    {
        private Persona persona ;
        private String idUsuario;
        private String idRol;
        private String clave;
        private int estado;

        public Usuario() {
            
        }
        public Usuario( Persona persona,String idUsuario, String idRol, String clave, int estado)
        {
            this.persona = new Persona(persona.getIdPersona(), persona.getNombres(), persona.getApellidos(),persona.getCodigoDocumento(), persona.getNumeroDocumento(), persona.getCorreo(), persona.getUsuarioRegistro(), persona.getFechaRegistro());
            this.idUsuario = idUsuario;
            this.idRol = idRol;
            this.clave = clave;
            this.estado = estado;
        }

        public String getIdUsuario()
        {
            return idUsuario;
        }

        public void setIdUsuario(String idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public String getIdRol()
        {
            return idRol;
        }

        public void setIdRol(String idRol)
        {
            this.idRol = idRol;
        }

        public String getClave()
        {
            return clave;
        }

        public void setClave(String clave)
        {
            this.clave = clave;
        }

        public int getEstado()
        {
            return estado;
        }

        public void setEstado(int estado)
        {
            this.estado = estado;
        }

    }
}

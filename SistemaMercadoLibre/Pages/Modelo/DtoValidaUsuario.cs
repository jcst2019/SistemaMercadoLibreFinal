namespace SistemaMercadoLibre.Pages.Modelo
{
    public class DtoValidaUsuario
    {
        private int resultado;
        private String idPersona;
        private String idUsuario;
        private String datos;

        public DtoValidaUsuario()
        {

        }
        public DtoValidaUsuario(int resultado, String idUsuario,String idPersona, String datos)
        {
            this.resultado = resultado;
            this.idUsuario = idUsuario;
            this.idPersona = idPersona;
            this.datos = datos;
        }

        public int getResultado()
        {
            return resultado;
        }

        public void setResultado(int resultado)
        {
            this.resultado = resultado;
        }

        public String getIdUsuario()
        {
            return idUsuario;
        }

        public void setIdUsuario(String idUsuario)
        {
            this.idUsuario = idUsuario;
        }
        
        public String getIdidPersona()
        {
            return idPersona;
        }

        public void setIdidPersona(String idPersona)
        {
            this.idPersona = idPersona;
        }
        public String getDatos()
        {
            return datos;
        }

        public void setDatos(String datos)
        {
            this.datos = datos;
        }
    }
}

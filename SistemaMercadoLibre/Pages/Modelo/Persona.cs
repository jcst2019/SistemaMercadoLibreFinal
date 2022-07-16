namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Persona
    {
        private int idPersona;
        private string nombres;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string direccion;
        private string telefono;
        private int tipoDocumento;
        private string numDocumento;
        private DateTime fechaNacimiento;
        private int estado;

        public Persona(int idPersona, string nombres, string apellidoPaterno, string apellidoMaterno, string direccion, string telefono, int tipoDocumento, string numDocumento, DateTime fechaNacimiento, int estado)
        {
            this.idPersona = idPersona;
            this.nombres = nombres;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.direccion = direccion;
            this.telefono = telefono;
            this.tipoDocumento = tipoDocumento;
            this.numDocumento = numDocumento;
            this.fechaNacimiento = fechaNacimiento;
            this.estado = estado;
        }

        public int IdPersona { get => idPersona; set => idPersona = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string NumDocumento { get => numDocumento; set => numDocumento = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
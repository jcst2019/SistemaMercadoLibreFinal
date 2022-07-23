namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Recepcion
    {
        private string idRecepcion;
        private DateTime fechaRegistro;
        private string observacion;
        private string numComprobante;
        private int estado;
        private string idUsuario;
        private string idVenta;
        private string nroOrden;
        private DateTime fechaModificacion;

        public Recepcion() { }

        public Recepcion(string idRecepcion, DateTime fechaRegistro, string observacion, string numComprobante, int estado, string idUsuario, string idVenta, string nroOrden, DateTime fechaModificacion)
        {
            this.idRecepcion = idRecepcion;
            this.fechaRegistro = fechaRegistro;
            this.observacion = observacion;
            this.numComprobante = numComprobante;
            this.estado = estado;
            this.idUsuario = idUsuario;
            this.idVenta = idVenta;
            this.nroOrden = nroOrden;
            this.fechaModificacion = fechaModificacion;
        }

        public string IdRecepcion { get => idRecepcion; set => idRecepcion = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string NumComprobante { get => numComprobante; set => numComprobante = value; }
        public int Estado { get => estado; set => estado = value; }
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string IdVenta { get => idVenta; set => idVenta = value; }
        public string NroOrden { get => nroOrden; set => nroOrden = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
    }
}

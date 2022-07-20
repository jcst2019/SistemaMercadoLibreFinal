namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Audicion
    {
        private int idAuditoria;
        private int idRecepcion;
        private int idVenta;
        private DateTime fechaventa;
        private DateTime fechamodificacionAudicion;
        private DateTime fechamodificacionRecepcion;
        private string observacion;
        private string nroOrden;
        private int estado;
        private int estadoRecepcion;
        private string detalleAudicion;

        public Audicion() { }

        public Audicion(int idAuditoria, int idRecepcion, int idVenta, DateTime fechaventa, DateTime fechamodificacionAudicion, string observacion, string nroOrden, int estado, string detalleAudicion, DateTime fechamodificacionRecepcion, int estadoRecepcion)
        {
            this.idAuditoria = idAuditoria;
            this.idRecepcion = idRecepcion;
            this.idVenta = idVenta;
            this.fechaventa = fechaventa;
            this.fechamodificacionAudicion = fechamodificacionAudicion;
            this.observacion = observacion;
            this.nroOrden = nroOrden;
            this.estado = estado;
            this.detalleAudicion = detalleAudicion;
            this.fechamodificacionRecepcion = fechamodificacionRecepcion;
            this.estadoRecepcion = estadoRecepcion;
        }

        public int IdAuditoria { get => idAuditoria; set => idAuditoria = value; }
        public int IdRecepcion { get => idRecepcion; set => idRecepcion = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
        public DateTime Fechaventa { get => fechaventa; set => fechaventa = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string NroOrden { get => nroOrden; set => nroOrden = value; }
        public int Estado { get => estado; set => estado = value; }
        public DateTime FechamodificacionAudicion { get => fechamodificacionAudicion; set => fechamodificacionAudicion = value; }
        public string DetalleAudicion { get => detalleAudicion; set => detalleAudicion = value; }
        public DateTime FechamodificacionRecepcion { get => fechamodificacionRecepcion; set => fechamodificacionRecepcion = value; }
        public int EstadoRecepcion { get => estadoRecepcion; set => estadoRecepcion = value; }
    }
}

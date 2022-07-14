namespace SistemaMercadoLibre.Pages.Modelo
{
    public class DtoGuiasPendientes
    {
        private String idVenta;
        private String idCliente;
        private String datosCliente;
        private String idProducto;
        private String descripcionProducto;
        private String fechaVenta;
        private String fechaEstado;
        private String desEstadoProducto;
        private int estadoProducto;

        public DtoGuiasPendientes()
        { 
        }

        public DtoGuiasPendientes(String idVenta, String idCliente, String datosCliente, String idProducto, String descripcionProducto, String fechaVenta, String fechaEstado, String desEstadoProducto, int estadoProducto)
        {
            this.idVenta = idVenta;
            this.idCliente = idCliente;
            this.datosCliente = datosCliente;
            this.idProducto = idProducto;
            this.descripcionProducto = descripcionProducto;
            this.fechaVenta = fechaVenta;
            this.fechaEstado = fechaEstado;
            this.desEstadoProducto = desEstadoProducto;
            this.estadoProducto = estadoProducto;
        }

        public String getIdVenta()
        {
            return idVenta;
        }

        public void setIdVenta(String idVenta)
        {
            this.idVenta = idVenta;
        }

        public String getIdCliente()
        {
            return idCliente;
        }

        public void setIdCliente(String idCliente)
        {
            this.idCliente = idCliente;
        }

        public String getDatosCliente()
        {
            return datosCliente;
        }

        public void setDatosCliente(String datosCliente)
        {
            this.datosCliente = datosCliente;
        }

        public String getIdProducto()
        {
            return idProducto;
        }

        public void setIdProducto(String idProducto)
        {
            this.idProducto = idProducto;
        }

        public String getDescripcionProducto()
        {
            return descripcionProducto;
        }

        public void setDescripcionProducto(String descripcionProducto)
        {
            this.descripcionProducto = descripcionProducto;
        }

        public String getFechaVenta()
        {
            return fechaVenta;
        }

        public void setFechaVenta(String fechaVenta)
        {
            this.fechaVenta = fechaVenta;
        }

        public String getFechaEstado()
        {
            return fechaEstado;
        }

        public void setFechaEstado(String fechaEstado)
        {
            this.fechaEstado = fechaEstado;
        }

        public String getDesEstadoProducto()
        {
            return desEstadoProducto;
        }

        public void setDesEstadoProducto(String desEstadoProducto)
        {
            this.desEstadoProducto = desEstadoProducto;
        }
        public int getEstadoProducto()
        {
            return estadoProducto;
        }

        public void setEstadoProducto(int estadoProducto)
        {
            this.estadoProducto = estadoProducto;
        }
    }
}

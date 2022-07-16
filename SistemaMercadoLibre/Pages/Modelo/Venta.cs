namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Venta
    {
        private int idVenta;
        private string nroOrden;
        private string nombreProducto;
        private string nombreProveedor;
        private int cantidad;
        private DateTime fechaRegistro;
        private Double precio;
        private Double importe;
        private Double igv;
        private Double subtotal;
        private int estado;

        
        public Venta() { }

        public Venta(int idVenta, string nroOrden, string nombreProducto, string nombreProveedor, int cantidad, DateTime fechaRegistro, double precio, double importe, double igv, double subtotal, int estado)
        {
            this.idVenta = idVenta;
            this.nroOrden = nroOrden;
            this.nombreProducto = nombreProducto;
            this.nombreProveedor = nombreProveedor;
            this.cantidad = cantidad;
            this.fechaRegistro = fechaRegistro;
            this.precio = precio;
            this.importe = importe;
            this.igv = igv;
            this.subtotal = subtotal;
            this.estado = estado;
        }

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public string NroOrden { get => nroOrden; set => nroOrden = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string NombreProveedor { get => nombreProveedor; set => nombreProveedor = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public double Precio { get => precio; set => precio = value; }
        public double Importe { get => importe; set => importe = value; }
        public double Igv { get => igv; set => igv = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
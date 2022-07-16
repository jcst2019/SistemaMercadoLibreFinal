namespace SistemaMercadoLibre.Pages.Modelo
{
    public class Proveedor
    {
        private int idProveedor;
        private int tipodocumento;
        private string numDocumento;
        private string nombre;
        private int estado;

        Proveedor() { }

        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public int Tipodocumento { get => tipodocumento; set => tipodocumento = value; }
        public string NumDocumento { get => numDocumento; set => numDocumento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
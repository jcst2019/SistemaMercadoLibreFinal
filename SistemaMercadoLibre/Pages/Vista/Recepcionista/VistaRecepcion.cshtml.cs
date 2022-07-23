using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;
using System.Data.SqlClient;

namespace SistemaMercadoLibre.Pages.Vista.Recepcionista
{
    public class VistaRecepcionModel : PageModel
    {
        //public List<Categoria> lista = new List<Categoria>();
        public List<Venta> lstVenta = new List<Venta>();
        public String errorMessage = "";
        public String successMessage = "";
        SqlConnection conn = GestionDatos.conectar();
        public Venta detalleVenta = new Venta();
        public void OnGet()
        {
            lstVenta = GestionaRecepcion.mostrarVentasEnTabla(conn);

        }

        public void OnPostAceptar()
        {
            string idVenta = Request.Form["idVenta"];
            int estado = Int32.Parse(Request.Form["estado"]);
            string observacion = Request.Form["observacion"];

            Venta venta = new Venta();
            venta.IdVenta = Request.Form["idVenta"];
            venta.Estado = Int32.Parse(Request.Form["estado"]);

            string idUsuario = HttpContext.Session.GetString("ID_USUARIO");
            string respuesta = GestionaRecepcion.actualizarEstado(conn, venta, observacion, idUsuario);
            Console.WriteLine("respuesta --> " + respuesta.ToString());
            lstVenta = GestionaRecepcion.mostrarVentasEnTabla(conn);
        }

        public void OnPostVerDetalle()
        {
            string idVenta = Request.Form["idVentaDetalle"];
            detalleVenta = GestionaRecepcion.solicitarDatosVenta(conn, idVenta);
            Console.WriteLine("respuesta --> " + detalleVenta.ToString());
            lstVenta = GestionaRecepcion.mostrarVentasEnTabla(conn);

        }
    }
}

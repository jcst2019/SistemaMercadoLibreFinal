using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;
using System.Data.SqlClient;

namespace SistemaMercadoLibre.Pages.Vista.Almacenista
{
    public class VistaAlmacenistaModel : PageModel
    {
        public List<Audicion> lstAudicion = new List<Audicion>();
        public String errorMessage = "";
        public String successMessage = "";
        SqlConnection conn = GestionDatos.conectar();
        public void OnGet()
        {
            lstAudicion = GestionarAlmacen.obtenerListPorAlmacenar(conn);
        }

        public void OnPostAceptar()
        {
            Audicion audicion = new Audicion();
            audicion.IdAuditoria = Request.Form["idAudicion"];
            audicion.Estado = Int32.Parse(Request.Form["estado"]);
            audicion.IdVenta = Request.Form["idVenta"];

            string respuesta = GestionarAlmacen.aceptarIngresoAlmacen(conn, audicion);
            Console.WriteLine("respuesta --> " + respuesta.ToString());

            //Actualizar Estado Producto
            lstAudicion = GestionarAuditoria.obtenerListAudicion(conn);
        }
    }
}

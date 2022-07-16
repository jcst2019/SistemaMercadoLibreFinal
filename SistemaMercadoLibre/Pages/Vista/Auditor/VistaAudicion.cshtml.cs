using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;
using System.Data.SqlClient;

namespace SistemaMercadoLibre.Pages.Vista.Auditor
{
    public class VistaAudicionModel : PageModel
    {
        public List<Audicion> lstAudicion = new List<Audicion>();
        public String errorMessage = "";
        public String successMessage = "";
        SqlConnection conn = GestionDatos.conectar();
        public void OnGet()
        {
            lstAudicion = GestionarAuditoria.obtenerListAudicion(conn);
        }

        public void OnPostAceptar()
        {
            Audicion audicion = new Audicion();
            audicion.IdAuditoria = Int32.Parse(Request.Form["idAudicion"]);
            audicion.Estado = Int32.Parse(Request.Form["estado"]);
            audicion.DetalleAudicion = Request.Form["detalleAudicion"];

            string respuesta = GestionarAuditoria.aceptarRechazarProductoAuditor(conn, audicion);
            Console.WriteLine("respuesta --> " + respuesta.ToString());
        }
    }
}

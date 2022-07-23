using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;
using System.Data.SqlClient;

namespace SistemaMercadoLibre.Pages.Vista.Recepcionista
{
    public class VistaAsistenteRecepcionModel : PageModel
    {
        public List<Recepcion> lstRecepcion = new List<Recepcion>();
        public String errorMessage = "";
        public String successMessage = "";
        SqlConnection conn = GestionDatos.conectar();
        public void OnGet()
        {
            string idUsuario = HttpContext.Session.GetString("ID_USUARIO");
            lstRecepcion = GestionaRecepcion.RecepcionadosPorGenerarComprobante(conn,idUsuario);
        }

        public void OnPostAceptar()
        {
            Recepcion recepcion = new Recepcion();
            recepcion.IdRecepcion = Request.Form["idRecepcion"];
            recepcion.Estado = Int32.Parse(Request.Form["estado"]);

            recepcion.IdUsuario = HttpContext.Session.GetString("ID_USUARIO");
            string respuesta = GestionaRecepcion.actualizarRecepcion(conn, recepcion);
            Console.WriteLine("respuesta --> " + respuesta.ToString());

            lstRecepcion = GestionaRecepcion.RecepcionadosPorGenerarComprobante(conn, recepcion.IdUsuario);
        }
    }
}

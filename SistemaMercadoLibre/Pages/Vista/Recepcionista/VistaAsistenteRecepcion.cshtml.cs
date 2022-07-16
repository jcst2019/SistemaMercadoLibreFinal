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
            lstRecepcion = GestionaRecepcion.RecepcionadosPorGenerarComprobante(conn);
        }

        public void OnPostAceptar()
        {
            Recepcion recepcion = new Recepcion();
            recepcion.IdVenta = Int32.Parse(Request.Form["idRecepcion"]);
            recepcion.Estado = Int32.Parse(Request.Form["estado"]);

            string respuesta = GestionaRecepcion.actualizarRecepcion(conn, recepcion);
            Console.WriteLine("respuesta --> " + respuesta.ToString());
        }
    }
}

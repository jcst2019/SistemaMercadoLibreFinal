using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Vista.Autorizar
{
    public class EnviarJefeAlmacenModel : PageModel
    {
        public List<DtoGuiasPendientes> lista = new List<DtoGuiasPendientes>();
        public String errorMessage = "";
        public String successMessage = "";
        public int RECOLECTADO = 10; //Constante RECOLECTADO
        public int ENVIAR_AUTORIZAR_ALMACEN = 11; //Constante ENVIARAUTORIZARALMACEN
        public void OnGet()
        {

            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setEstadoProducto(RECOLECTADO);
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);
        }
        public void OnPostRecolectar()
        {
            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setIdProducto(Request.Form["txtIdProducto"].ToString());
            dto.setEstadoProducto(ENVIAR_AUTORIZAR_ALMACEN);
            //Modificar a Estado ENVIARAUTORIZARALMACEN(11)
            String err = GestionGuiasPendientes.ActualizarEstadoProducto(dto);
            //Lista estado RECOLECTADO(10)
            dto.setEstadoProducto(RECOLECTADO);
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);

            successMessage = "Producto Actualizado Correctamente.";

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Vista.Autorizar
{
    public class AutorizarJefeAlmacenModel : PageModel
    {
        public List<DtoGuiasPendientes> lista = new List<DtoGuiasPendientes>();
        public String errorMessage = "";
        public String successMessage = "";
        public int ENVIAR_AUTORIZAR_ALMACEN = 11; //Constante ENVIARAUTORIZARALMACEN
        public int AUTORIZADO_JEFE_ALMACEN = 12; //Constante AUTORIZADO_JEFE_ALMACEN
        public void OnGet()
        {

            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setEstadoProducto(ENVIAR_AUTORIZAR_ALMACEN);
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);
        }
        public void OnPostRecolectar()
        {
            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setIdProducto(Request.Form["txtIdProducto"].ToString());
            dto.setEstadoProducto(AUTORIZADO_JEFE_ALMACEN);
            //Modificar A ESTADO AUTORIZADO_JEFE_ALMACEN(12)
            String err = GestionGuiasPendientes.ActualizarEstadoProducto(dto);
            dto.setEstadoProducto(ENVIAR_AUTORIZAR_ALMACEN);
            //Lista estado ENVIAR_AUTORIZAR_ALMACEN(11)
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);

            successMessage = "Producto Actualizado Correctamente.";

        }
    }
}

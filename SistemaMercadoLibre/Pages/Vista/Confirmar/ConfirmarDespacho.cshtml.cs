using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Vista.Confirmar
{
    public class ConfirmarDespachoModel : PageModel
    {
        public List<DtoGuiasPendientes> lista = new List<DtoGuiasPendientes>();
        public String errorMessage = "";
        public String successMessage = "";
        public int EMPAQUE_CONFIRMADO = 13; //Constante EMPAQUE_CONFIRMADO
        public int DESPACHO_CONFIRMADO = 14; //Constante AUTORIZADO_JEFE_ALMACEN
       
        public void OnGet()
        {

            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setEstadoProducto(EMPAQUE_CONFIRMADO);
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);
        }
        public void OnPostRecolectar()
        {
            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setIdProducto(Request.Form["txtIdProducto"].ToString());
            dto.setEstadoProducto(DESPACHO_CONFIRMADO);
            //Modificar a Estado DESPACHO_CONFIRMADO(14)
            String err = GestionGuiasPendientes.ActualizarEstadoProducto(dto);
            //Lista estado EMPAQUE_CONFIRMADO(13)
            dto.setEstadoProducto(EMPAQUE_CONFIRMADO);
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);

            successMessage = "Producto Actualizado Correctamente.";

        }
    }
}

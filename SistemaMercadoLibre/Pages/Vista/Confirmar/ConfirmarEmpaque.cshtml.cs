using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Vista.Confirmar
{
    public class ConfirmarEmpaqueModel : PageModel
    {
        public List<DtoGuiasPendientes> lista = new List<DtoGuiasPendientes>();
        public String errorMessage = "";
        public String successMessage = "";
        public int AUTORIZADO_JEFE_ALMACEN = 12; //Constante AUTORIZADO_JEFE_ALMACEN
        public int EMPAQUE_CONFIRMADO = 13; //Constante EMPAQUE_CONFIRMADO
        public void OnGet()
        {

            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setEstadoProducto(AUTORIZADO_JEFE_ALMACEN);
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);
        }
        public void OnPostRecolectar()
        {
            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setIdProducto(Request.Form["txtIdProducto"].ToString());
            dto.setEstadoProducto(EMPAQUE_CONFIRMADO);
            //Modificar a Estado EMPAQUE_CONFIRMADO(13)
            String err = GestionGuiasPendientes.ActualizarEstadoProducto(dto);
            //Lista estado AUTORIZADO_JEFE_ALMACEN(12)
            dto.setEstadoProducto(AUTORIZADO_JEFE_ALMACEN);
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);

            successMessage = "Producto Actualizado Correctamente.";

        }
    }
}

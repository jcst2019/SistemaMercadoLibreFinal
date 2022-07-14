using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Vista.Guias
{
    public class DescargarGuiasModel : PageModel
    {
        public List<DtoGuiasPendientes> lista = new List<DtoGuiasPendientes>();
        public String errorMessage = "";
        public String successMessage = "";
        public int ALMACENADO = 8; //Constante Almacenado
        public int RECOLECTADO = 9; //Constante Recolectado
        public void OnGet()
        {
            
            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setEstadoProducto(ALMACENADO);
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);
        }
        public void OnPostRecolectar()
        {
            DtoGuiasPendientes dto = new DtoGuiasPendientes();
            dto.setIdProducto(Request.Form["txtIdProducto"].ToString());
            dto.setEstadoProducto(RECOLECTADO);
            //Modificar
            String err = GestionGuiasPendientes.ActualizarEstadoProducto(dto);
            dto.setEstadoProducto(ALMACENADO);
            lista = GestionGuiasPendientes.ListarGuiasPendientes(dto);

            successMessage = "Producto Actualizado Correctamente.";

        }
    }
}

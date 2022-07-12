using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Vista.Categorias
{
    public class CrearCategoriaModel : PageModel
    {
        public Categoria categoriaInfo = new Categoria();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            categoriaInfo.setDescripcion(Request.Form["txtDescripcion"].ToString());
            if (categoriaInfo.getDescripcion().Length == 0)
            {
                errorMessage = "Se requiere llenar la Descripción.";
                return;
            }
            else {
                String idNewCategoria = GestionCategoria.InsertarCategoria(categoriaInfo);
                successMessage = "Nuevo Cliente Añadido Correctamente";
            }

           
        }
    }
}

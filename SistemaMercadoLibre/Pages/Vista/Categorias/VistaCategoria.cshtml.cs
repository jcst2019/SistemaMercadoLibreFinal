using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Vista.VistaCategoria
{
    public class CategoriaModel : PageModel
    {

        public List<Categoria> lista = new List<Categoria>();
        public void OnGet()
        {
            lista = GestionCategoria.Listar();
        }

        public void OnPostGuardar()
        {
            Categoria categoria = new Categoria();
            categoria.setId(Request.Form["txtID"].ToString());
            categoria.setDescripcion(Request.Form["txtDescripcion"].ToString());
            categoria.setEstado(Request.Form["cboActivo"].ToString());
            if (categoria.getId().Length == 0)
            { //Registrar
                String idNewCategoria = GestionCategoria.InsertarCategoria(categoria);
                lista = GestionCategoria.Listar();
            }
            else {
                //Modificar
                String idNewCategoria = GestionCategoria.ActualizarCategoria(categoria);
                lista = GestionCategoria.Listar();
            }
            

        }
        public void OnPostBaja()
        {
            Categoria categoria = new Categoria();
            categoria.setId(Request.Form["txtIdBaja"].ToString());
            categoria.setDescripcion(Request.Form["txtDescripcionBaja"].ToString());
            categoria.setEstado("0");// Cero Significa de Baja
            //Modificar
            String idNewCategoria = GestionCategoria.ActualizarCategoria(categoria);
            lista = GestionCategoria.Listar();
          
        }
    }
}

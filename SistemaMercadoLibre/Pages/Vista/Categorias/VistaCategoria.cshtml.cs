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
        public String errorMessage = "";
        public String successMessage = "";
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
            if (categoria.getDescripcion().Length == 0)
            {
                lista = GestionCategoria.Listar();
                errorMessage = "Se requiere llenar la Descripción.";
                //return;
            }
            else
            {
                if (categoria.getId().Length == 0)
                { //Registrar
                    String idNewCategoria = GestionCategoria.InsertarCategoria(categoria);
                    lista = GestionCategoria.Listar();
                    successMessage = "Nuevo Cliente Añadido Correctamente.";
                }
                else
                {
                    //Modificar
                    String idNewCategoria = GestionCategoria.ActualizarCategoria(categoria);
                    lista = GestionCategoria.Listar();
                    successMessage = "Cliente Editado Correctamente.";
                }
                
            }      
        }
        public void OnPostBaja()
        {
            Categoria categoria = new Categoria();
            categoria.setId(Request.Form["txtIdBaja"].ToString());
            categoria.setDescripcion(Request.Form["txtDescripcionBaja"].ToString());
            categoria.setEstado("0");// Cero Significa de Baja
            //Modificar
            String err = GestionCategoria.ActualizarCategoria(categoria);
            lista = GestionCategoria.Listar();
            successMessage = "Cliente dado de Baja Correctamente.";

        }
    }
}

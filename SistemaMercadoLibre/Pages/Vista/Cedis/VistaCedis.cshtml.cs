using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Vista.Cedis
{
    public class VistaCedisModel : PageModel
    {
        public List<Cedi> lista = new List<Cedi>();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            lista = GestionCedi.Listar();
        }

        public void OnPostGuardar()
        {
            Cedi cedi = new Cedi();
            cedi.setId(Request.Form["txtID"].ToString());
            cedi.setNombre(Request.Form["txtNombre"].ToString());
            cedi.setUbicacion(Request.Form["txtUbicacion"].ToString());
            cedi.setDireccion(Request.Form["txtDireccion"].ToString());
            cedi.setCiudad(Request.Form["txtCiudad"].ToString());

            /*Categoria categoria = new Categoria();
            categoria.setId(Request.Form["txtID"].ToString());
            categoria.setDescripcion(Request.Form["txtDescripcion"].ToString());
            categoria.setEstado(Request.Form["cboActivo"].ToString());
            categoria.setUsuarioRegistro(HttpContext.Session.GetString("ID_USUARIO"));*/
            //categoria.setUsuarioRegistro("123456");

            if (cedi.getNombre().Length == 0)
            {
                lista = GestionCedi.Listar();
                errorMessage = "Se requiere llenar el nombre del CEDIS";
                //return;
            }
            else
            {
                if (cedi.getId().Length == 0)
                {
                    //Registrar
                    String idNewCategoria = GestionCedi.InsertarCedi(cedi);
                    lista = GestionCedi.Listar();
                    successMessage = "Nuevo CEDI Añadido Correctamente.";
                }
                else
                {
                    //Modificar
                    String idNewCedi = GestionCedi.ActualizarCedi(cedi);
                    lista = GestionCedi.Listar();
                    successMessage = "CEDI Editado Correctamente.";
                }

            }
        }
    }
}

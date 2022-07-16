using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaMercadoLibre.Pages.Controlador;
using SistemaMercadoLibre.Pages.Modelo;

namespace SistemaMercadoLibre.Pages.Vista.Login
{

    public class LoginModel : PageModel
    {
        public String errorMessage = "";
        public void OnGet()
        {
        }
        public IActionResult OnPost(string email, string password) {
        
            DtoValidaUsuario dto = new DtoValidaUsuario();
            Usuario usuario = new Usuario();
            usuario.setCorreo(email);
            usuario.setClave(password);
  
            dto = GestionUsuario.ValidarAccesoUsuario(usuario);
            Console.WriteLine("test");
            Console.WriteLine(email);
            Console.WriteLine(password);
            if (dto.getResultado() == 1)
            {
                HttpContext.Session.SetString("NOMBRE_USUARIO", dto.getDatos());
                HttpContext.Session.SetString("ID_USUARIO", dto.getIdUsuario());
                return RedirectToPage("/Vista/Inicio/Inicio");
            }
            else {
                errorMessage = "Usuario o Clave inválidos";
                return null;
            }

            //HttpContext.Session.SetString("NOMBRE_USUARIO", "JUAN CARLOS SOLAR TORRES");
            //HttpContext.Session.SetString("USUARIO", email);
            //HttpContext.Session.SetString("ID_USUARIO", "U00001");

            //var id = HttpContext.Session.GetString("ID_USUARIO");

           

        }

    }
}

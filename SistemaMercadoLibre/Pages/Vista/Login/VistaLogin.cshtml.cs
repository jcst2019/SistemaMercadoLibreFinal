using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SistemaMercadoLibre.Pages.Vista.Login
{

    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string email, string password) {

            Console.WriteLine("test");
            Console.WriteLine(email);
            Console.WriteLine(password);
            HttpContext.Session.SetString("NOMBRE_USUARIO", "JUAN CARLOS SOLAR TORRES");
            //HttpContext.Session.SetString("USUARIO", email);
            HttpContext.Session.SetString("ID_USUARIO", "U00001");

            //var id = HttpContext.Session.GetString("ID_USUARIO");

            return RedirectToPage("/Vista/Inicio/Inicio");

        }

    }
}

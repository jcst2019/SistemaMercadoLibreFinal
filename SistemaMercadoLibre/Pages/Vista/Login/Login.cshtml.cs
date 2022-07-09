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

            return RedirectToPage("/Vista/Inicio/Inicio");

        }
    }
}

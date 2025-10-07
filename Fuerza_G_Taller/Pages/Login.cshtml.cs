using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fuerza_G_Taller.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            // Si quieres, aqu� puedes limpiar sesiones previas
        }

        public IActionResult OnPost()
        {
            // Ejemplo simple de login (despu�s se puede conectar a la base de datos)
            if (Username == "admin" && Password == "0000")
            {
                // Redirigir al Home
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Usuario o contrase�a incorrectos";
                return Page();
            }
        }
    }
}

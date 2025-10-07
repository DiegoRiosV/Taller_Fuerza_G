using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fuerza_G_Taller.Models;
using ServiceEntity = Fuerza_G_Taller.Models.Service;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Service
{
    public class CreateServiceModel : PageModel
    {
        private readonly ServiceRepository _repository;

        public CreateServiceModel(ServiceRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public ServiceEntity Service { get; set; } = new ServiceEntity();

        public void OnGet()
        {
            // Nada que cargar
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Add(Service);
            return RedirectToPage("IndexService");
        }
    }
}

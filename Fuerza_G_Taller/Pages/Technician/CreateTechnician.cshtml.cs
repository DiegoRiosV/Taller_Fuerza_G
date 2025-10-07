using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechnicianEntity = Fuerza_G_Taller.Models.Technician;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Technician
{
    public class CreateTechnician : PageModel
    {
        private readonly TechnicianRepository _repository;

        public CreateTechnician(TechnicianRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public TechnicianEntity Technician { get; set; } = new TechnicianEntity();

        public void OnGet()
        {
            // Nada que cargar por ahora
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Add(Technician);
            return RedirectToPage("IndexTechnician");
        }
    }
}

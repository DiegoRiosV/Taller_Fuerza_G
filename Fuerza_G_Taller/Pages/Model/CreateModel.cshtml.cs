using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelEntity = Fuerza_G_Taller.Models.Model;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Model
{
    public class CreateModel : PageModel
    {
        private readonly ModelRepository _repository;

        public CreateModel(ModelRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public ModelEntity Model { get; set; } = new ModelEntity();

        public void OnGet()
        {
            // Nada que cargar
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Add(Model);
            return RedirectToPage("Index");
        }
    }
}

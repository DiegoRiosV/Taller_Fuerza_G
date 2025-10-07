using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelEntity = Fuerza_G_Taller.Models.Model;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Model
{
    public class DeleteModel : PageModel
    {
        private readonly ModelRepository _repository;

        public DeleteModel(ModelRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public ModelEntity Model { get; set; } = new ModelEntity();

        public IActionResult OnGet(int id)
        {
            var modelEntity = _repository.GetById(id);
            if (modelEntity == null) return RedirectToPage("Index");

            Model = modelEntity;
            return Page();
        }

        public IActionResult OnPost()
        {
            _repository.Delete(Model.Id);
            return RedirectToPage("Index");
        }
    }
}

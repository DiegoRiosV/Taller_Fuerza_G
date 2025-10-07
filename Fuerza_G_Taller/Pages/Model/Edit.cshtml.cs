using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelEntity = Fuerza_G_Taller.Models.Model;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Model
{
    public class EditModel : PageModel
    {
        private readonly ModelRepository _repository;
        private readonly BrandRepository _brandRepository;

        public EditModel(ModelRepository repository, BrandRepository brandRepository)
        {
            _repository = repository;
            _brandRepository = brandRepository;
        }

        [BindProperty]
        public ModelEntity Model { get; set; } = new ModelEntity();

        public IEnumerable<SelectListItem> BrandsSelectList { get; set; } = new List<SelectListItem>();

        public IActionResult OnGet(int id)
        {
            var modelEntity = _repository.GetById(id);
            if (modelEntity == null) return RedirectToPage("Index");

            Model = modelEntity;

            BrandsSelectList = _brandRepository.GetAll()
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name });

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Update(Model);
            return RedirectToPage("Index");
        }
    }
}

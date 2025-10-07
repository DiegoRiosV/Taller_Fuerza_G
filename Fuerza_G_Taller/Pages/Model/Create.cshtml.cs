using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelEntity = Fuerza_G_Taller.Models.Model;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Model
{
    public class CreateModel : PageModel
    {
        private readonly ModelRepository _repository;
        private readonly BrandRepository _brandRepository;

        public CreateModel(ModelRepository repository, BrandRepository brandRepository)
        {
            _repository = repository;
            _brandRepository = brandRepository;
        }

        [BindProperty]
        public ModelEntity Model { get; set; } = new ModelEntity();

        public IEnumerable<SelectListItem> BrandsSelectList { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            BrandsSelectList = _brandRepository.GetAll()
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name });
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Add(Model);
            return RedirectToPage("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fuerza_G_Taller.Models;
using BrandModel = Fuerza_G_Taller.Models.Brand;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Brand
{
    public class CreateBrand : PageModel
    {
        private readonly BrandRepository _repository;

        public CreateBrand(BrandRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public BrandModel Brand { get; set; } = new BrandModel();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Add(Brand);
            return RedirectToPage("Index");
        }
    }
}

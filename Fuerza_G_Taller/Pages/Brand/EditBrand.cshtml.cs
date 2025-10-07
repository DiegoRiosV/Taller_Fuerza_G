using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fuerza_G_Taller.Models;
using BrandModel = Fuerza_G_Taller.Models.Brand;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Brand
{
    public class EditBrand : PageModel
    {
        private readonly BrandRepository _repository;

        public EditBrand(BrandRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public BrandModel Brand { get; set; } = new BrandModel();


        public IActionResult OnGet(int id)
        {
            var brand = _repository.GetById(id);
            if (brand == null) return RedirectToPage("Index");

            Brand = brand;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Update(Brand);
            return RedirectToPage("Index");
        }
    }
}

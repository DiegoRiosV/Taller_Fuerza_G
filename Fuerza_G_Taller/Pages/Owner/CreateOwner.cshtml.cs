using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OwnerEntity = Fuerza_G_Taller.Models.Owner;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Owner
{
    public class CreateOwner : PageModel
    {
        private readonly OwnerRepository _repository;

        public CreateOwner(OwnerRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public OwnerEntity Owner { get; set; } = new OwnerEntity();

        public void OnGet()
        {
            // No se necesita lógica por ahora
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _repository.Add(Owner);
            return RedirectToPage("IndexOwner");
        }
    }
}

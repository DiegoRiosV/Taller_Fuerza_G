using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OwnerEntity = Fuerza_G_Taller.Models.Owner;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Owner
{
    public class EditOwner : PageModel
    {
        private readonly OwnerRepository _repository;

        public EditOwner(OwnerRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public OwnerEntity Owner { get; set; } = new OwnerEntity();

        public IActionResult OnGet(int id)
        {
            var ownerEntity = _repository.GetById(id);
            if (ownerEntity == null) return RedirectToPage("Index");

            Owner = ownerEntity;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _repository.Update(Owner);
            return RedirectToPage("Index");
        }
    }
}

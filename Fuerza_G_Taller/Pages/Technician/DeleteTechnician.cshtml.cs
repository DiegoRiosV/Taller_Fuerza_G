using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechnicianEntity = Fuerza_G_Taller.Models.Technician;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Technician
{
    public class DeleteTechnician : PageModel
    {
        private readonly TechnicianRepository _repository;

        public DeleteTechnician(TechnicianRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public TechnicianEntity Technician { get; set; } = new TechnicianEntity();

        public IActionResult OnGet(int id)
        {
            var tech = _repository.GetById(id);
            if (tech == null) return RedirectToPage("IndexTechnician");

            Technician = tech;
            return Page();
        }

        public IActionResult OnPost()
        {
            _repository.Delete(Technician.Id);
            return RedirectToPage("IndexTechnician");
        }
    }
}

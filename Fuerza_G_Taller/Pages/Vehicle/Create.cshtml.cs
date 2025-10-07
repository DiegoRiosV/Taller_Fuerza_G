using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleEntity = Fuerza_G_Taller.Models.Vehicle;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Vehicle
{
    public class CreateModel : PageModel
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly OwnerRepository _ownerRepository;
        private readonly ModelRepository _modelRepository;

        public CreateModel(VehicleRepository vehicleRepository,
                           OwnerRepository ownerRepository,
                           ModelRepository modelRepository)
        {
            _vehicleRepository = vehicleRepository;
            _ownerRepository = ownerRepository;
            _modelRepository = modelRepository;
        }

        [BindProperty]
        public VehicleEntity Vehicle { get; set; } = new VehicleEntity();

        public IEnumerable<SelectListItem> OwnersSelectList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> ModelsSelectList { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            OwnersSelectList = _ownerRepository.GetAll()
                .Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Name + " " + o.FirstLastName });

            ModelsSelectList = _modelRepository.GetAll()
                .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Name });
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _vehicleRepository.Add(Vehicle);
            return RedirectToPage("Index");
        }
    }
}

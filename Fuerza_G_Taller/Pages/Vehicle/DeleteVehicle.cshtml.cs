using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleEntity = Fuerza_G_Taller.Models.Vehicle;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Vehicle
{
    public class DeleteVehicle : PageModel
    {
        private readonly VehicleRepository _vehicleRepository;

        public DeleteVehicle(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [BindProperty]
        public VehicleEntity Vehicle { get; set; } = new VehicleEntity();

        public IActionResult OnGet(int id)
        {
            var vehicleEntity = _vehicleRepository.GetById(id);
            if (vehicleEntity == null) return RedirectToPage("Index");

            Vehicle = vehicleEntity;
            return Page();
        }

        public IActionResult OnPost()
        {
            _vehicleRepository.Delete(Vehicle.Id);
            return RedirectToPage("Index");
        }
    }
}

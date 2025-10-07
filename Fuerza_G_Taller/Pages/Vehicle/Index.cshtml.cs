using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleEntity = Fuerza_G_Taller.Models.Vehicle;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Vehicle
{
    public class IndexModel : PageModel
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly OwnerRepository _ownerRepository;
        private readonly ModelRepository _modelRepository;

        public IndexModel(VehicleRepository vehicleRepository,
                          OwnerRepository ownerRepository,
                          ModelRepository modelRepository)
        {
            _vehicleRepository = vehicleRepository;
            _ownerRepository = ownerRepository;
            _modelRepository = modelRepository;
        }

        public List<VehicleView> Vehicles { get; set; } = new List<VehicleView>();

        public void OnGet()
        {
            var vehicles = _vehicleRepository.GetAll();
            var owners = _ownerRepository.GetAll().ToDictionary(o => o.Id, o => o.Name + " " + o.FirstLastName);
            var models = _modelRepository.GetAll().ToDictionary(m => m.Id, m => m.Name);

            Vehicles = vehicles.Select(v => new VehicleView
            {
                Id = v.Id,
                Plate = v.Plate,
                Year = v.Year,
                Color = v.Color,
                Type = v.Type,
                OwnerId = v.OwnerId,
                OwnerName = owners.ContainsKey(v.OwnerId) ? owners[v.OwnerId] : "N/A",
                ModelId = v.ModelId ?? 0,
                ModelName = v.ModelId.HasValue && models.ContainsKey(v.ModelId.Value) ? models[v.ModelId.Value] : "N/A"
            }).ToList();
        }

        public class VehicleView
        {
            public int Id { get; set; }
            public string Plate { get; set; } = string.Empty;
            public int? ModelId { get; set; }
            public string ModelName { get; set; } = string.Empty;
            public int OwnerId { get; set; }
            public string OwnerName { get; set; } = string.Empty;
            public short? Year { get; set; }
            public string Color { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
        }
    }
}

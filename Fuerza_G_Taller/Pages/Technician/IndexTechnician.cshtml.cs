using Microsoft.AspNetCore.Mvc.RazorPages;
using TechnicianEntity = Fuerza_G_Taller.Models.Technician;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Technician
{
    public class IndexTechnician : PageModel
    {
        private readonly TechnicianRepository _repository;

        public IndexTechnician(TechnicianRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TechnicianEntity> Technicians { get; set; } = new List<TechnicianEntity>();

        public void OnGet()
        {
            Technicians = _repository.GetAll();
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using Fuerza_G_Taller.Models;
using ServiceEntity = Fuerza_G_Taller.Models.Service;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Service
{
    public class IndexService : PageModel
    {
        private readonly ServiceRepository _repository;

        public IndexService(ServiceRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ServiceEntity> Services { get; set; } = new List<ServiceEntity>();

        public void OnGet()
        {
            Services = _repository.GetAll();
        }
    }
}

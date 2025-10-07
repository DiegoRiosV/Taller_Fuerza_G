using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceEntity = Fuerza_G_Taller.Models.Service;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Service
{
    public class DeleteServiceModel : PageModel
    {
        private readonly ServiceRepository _repository;

        public DeleteServiceModel(ServiceRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public ServiceEntity Service { get; set; } = new ServiceEntity();

        public IActionResult OnGet(int id)
        {
            var service = _repository.GetById(id);
            if (service == null) return RedirectToPage("IndexService");

            Service = service;
            return Page();
        }

        public IActionResult OnPost()
        {
            _repository.Delete(Service.Id);
            return RedirectToPage("IndexService");
        }
    }
}

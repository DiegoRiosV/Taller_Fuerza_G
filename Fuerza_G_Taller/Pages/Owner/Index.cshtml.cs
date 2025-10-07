using Microsoft.AspNetCore.Mvc.RazorPages;
using OwnerEntity = Fuerza_G_Taller.Models.Owner;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Owner
{
    public class IndexModel : PageModel
    {
        private readonly OwnerRepository _repository;

        public IndexModel(OwnerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<OwnerEntity> Owners { get; set; } = new List<OwnerEntity>();

        public void OnGet()
        {
            Owners = _repository.GetAll();
        }
    }
}

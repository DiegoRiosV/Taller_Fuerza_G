using Microsoft.AspNetCore.Mvc.RazorPages;
using Fuerza_G_Taller.Models;
using BrandModel = Fuerza_G_Taller.Models.Brand;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Brand
{
    public class IndexModel : PageModel
    {
        private readonly BrandRepository _repository;

        public IndexModel(BrandRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BrandModel> Brands { get; set; } = new List<BrandModel>();

        public void OnGet()
        {
            Brands = _repository.GetAll();
        }
    }
}

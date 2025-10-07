using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelEntity = Fuerza_G_Taller.Models.Model;
using Fuerza_G_Taller.Repositories;

namespace Fuerza_G_Taller.Pages.Model
{
    public class IndexModel : PageModel
    {
        private readonly ModelRepository _repository;
        private readonly BrandRepository _brandRepository;

        public IndexModel(ModelRepository repository, BrandRepository brandRepository)
        {
            _repository = repository;
            _brandRepository = brandRepository;
        }

        public List<ModelView> Models { get; set; } = new List<ModelView>();

        public void OnGet()
        {
            var models = _repository.GetAll();
            var brands = _brandRepository.GetAll().ToDictionary(b => b.Id, b => b.Name);

            Models = models.Select(m => new ModelView
            {
                Id = m.Id,
                Name = m.Name,
                BrandId = m.BrandId,
                BrandName = brands.ContainsKey(m.BrandId) ? brands[m.BrandId] : "N/A"
            }).ToList();
        }

        public class ModelView
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public int BrandId { get; set; }
            public string BrandName { get; set; } = string.Empty;
        }
    }
}

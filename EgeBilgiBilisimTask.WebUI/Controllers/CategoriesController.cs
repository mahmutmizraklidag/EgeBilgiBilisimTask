using EgeBilgiBilisimTask.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EgeBilgiBilisimTask.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiAdressCategory;
        public CategoriesController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiAdressCategory = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Categories";
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return BadRequest();
            
            var categories = await _httpClient.GetAsync(_apiAdressCategory + "/GetCategoryByProduct/" + id);
            if (categories.IsSuccessStatusCode)                                
            {
                var response = await categories.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Category>(response);
                return View(model);
            }

            return NotFound();
        }
    }
}

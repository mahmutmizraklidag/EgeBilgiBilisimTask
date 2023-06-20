using EgeBilgiBilisimTask.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EgeBilgiBilisimTask.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdressCategory;
        public CategoriesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiAdressCategory = "https://localhost:7246/api/Categories";
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

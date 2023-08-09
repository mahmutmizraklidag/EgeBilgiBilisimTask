using EgeBilgiBilisimTask.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EgeBilgiBilisimTask.WebUI.Controllers
{
    public class BrandsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiAdressBrand;

        public BrandsController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiAdressBrand = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Brands";
        }
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdressBrand);
            return View(model);

        }
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Brand>(_apiAdressBrand + "/GetBrandByProduct/" + id);
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;

namespace EgeBilgiBilisimTask.WebUI.ViewComponents
{
    public class Brands : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiAdress;
        public Brands(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiAdress = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Brands";
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdress);
            return View(brands);
        }
    }
}

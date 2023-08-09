using Microsoft.AspNetCore.Mvc;
using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;

namespace EgeBilgiBilisimTask.WebUI.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiAdress;
        public Categories(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiAdress = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Categories";
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories =  await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdress);
            return View(categories);
        }
       
    }
}

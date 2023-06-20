using Microsoft.AspNetCore.Mvc;
using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;

namespace EgeBilgiBilisimTask.WebUI.ViewComponents
{
    public class Brands : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdress;
        public Brands(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiAdress = "https://localhost:7246/api/Brands";
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdress);
            return View(brands);
        }
    }
}

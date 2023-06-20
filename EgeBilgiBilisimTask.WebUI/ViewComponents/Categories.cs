using Microsoft.AspNetCore.Mvc;
using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;

namespace EgeBilgiBilisimTask.WebUI.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdress;
        public Categories(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiAdress = "https://localhost:7246/api/Categories";
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories =  await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdress);
            return View(categories);
        }
       
    }
}

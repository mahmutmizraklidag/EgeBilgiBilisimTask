﻿using EgeBilgiBilisimTask.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EgeBilgiBilisimTask.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiAdressProduct;
        public ProductsController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiAdressProduct = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Products";
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            var product = await _httpClient.GetFromJsonAsync<Product>(_apiAdressProduct + "/GetGetProductByCategoryAndBrand/" + id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}

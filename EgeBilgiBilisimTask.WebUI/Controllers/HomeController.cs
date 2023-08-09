using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EgeBilgiBilisimTask.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiAdressContact;
        private readonly string _apiAdressSlider;
        private readonly string _apiAdressBrand;
        private readonly string _apiAdressNews;
        private readonly string _apiAdressProduct;
        public HomeController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiAdressContact = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Contacts";
            _apiAdressSlider = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Sliders";
            _apiAdressBrand = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Brands";
            _apiAdressNews = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/News";
            _apiAdressProduct = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Products";
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel();
            model.Sliders = await _httpClient.GetFromJsonAsync<List<Slider>>(_apiAdressSlider);
            model.Brands = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdressBrand);
            model.Products = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdressProduct);
            model.News = await _httpClient.GetFromJsonAsync<List<News>>(_apiAdressNews);

            return View(model);
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactUs(Contact entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync(_apiAdressContact, entity);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["mesaj"] = "<div class='alert alert-success'>Mesajınız Gönderildi... Teşekkürler...</div>";
                        return RedirectToAction(nameof(ContactUs));
                    }

                    else ModelState.AddModelError("", "Kayıt Başarısız!");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(entity);
        }

        
    }
}
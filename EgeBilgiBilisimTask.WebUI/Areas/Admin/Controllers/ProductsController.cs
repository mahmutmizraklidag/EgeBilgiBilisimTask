using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EgeBilgiBilisimTask.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiAdress;
        private readonly string _apiAdressCategory;
        private readonly string _apiAdressBrand;
        public ProductsController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiAdress = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Products";
            _apiAdressCategory = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Categories";
            _apiAdressBrand = $"{_configuration.GetSection("EgeBilgiBilisim")["baseUrlApi"]}/api/Brands";
        }
        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdress);
            return View(model);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public async Task<ActionResult> Create()
        {
            var list = await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdressCategory);
            ViewBag.CategoryId = new SelectList(list, "Id", "Name");
            var brand = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdressBrand);
            ViewBag.BrandId = new SelectList(brand, "Id", "Name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product entity, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) entity.Image = await FileHelper.FileLoaderAsync(Image);
                    var response = await _httpClient.PostAsJsonAsync(_apiAdress, entity);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    else ModelState.AddModelError("", "Kayıt Başarısız!");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            var list = await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdressCategory);
            ViewBag.CategoryId = new SelectList(list, "Id", "Name");
            var brand = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdressBrand);
            ViewBag.BrandId = new SelectList(brand, "Id", "Name");
            return View(entity);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<Product>(_apiAdress + "/" + id);
            if (user == null) return NotFound();
            var list = await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdressCategory);
            ViewBag.CategoryId = new SelectList(list, "Id", "Name");
            var brand = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdressBrand);
            ViewBag.BrandId = new SelectList(brand, "Id", "Name");
            return View(user);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Product entity, IFormFile? Image, bool? resmiSil)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (resmiSil == true)
                    {
                        entity.Image = string.Empty;
                    }
                    if (Image is not null) entity.Image = await FileHelper.FileLoaderAsync(Image);
                    var response = await _httpClient.PutAsJsonAsync(_apiAdress + "/" + id, entity);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    else ModelState.AddModelError("", "Kayıt Başarısız!");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            var list = await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdressCategory);
            ViewBag.CategoryId = new SelectList(list, "Id", "Name");
            var brand = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdressBrand);
            ViewBag.BrandId = new SelectList(brand, "Id", "Name");
            return View(entity);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<Product>(_apiAdress + "/" + id);
            if (user == null) return NotFound();
            var list = await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdressCategory);
            ViewBag.CategoryId = new SelectList(list, "Id", "Name");
            var brand = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdressBrand);
            ViewBag.BrandId = new SelectList(brand, "Id", "Name");
            return View(user);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Product entity)
        {
            try
            {
                var user = await _httpClient.DeleteAsync(_apiAdress + "/" + id);
                if (user.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
                else ModelState.AddModelError("", "Kayıt Silinemedi!");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            var list = await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdressCategory);
            ViewBag.CategoryId = new SelectList(list, "Id", "Name");
            var brand = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdressBrand);
            ViewBag.BrandId = new SelectList(brand, "Id", "Name");
            return View(entity);
        }
    }
}

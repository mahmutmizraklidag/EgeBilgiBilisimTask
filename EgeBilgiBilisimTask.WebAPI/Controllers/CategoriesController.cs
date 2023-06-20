using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EgeBilgiBilisimTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository<Category> _repository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetAsync(int id)
        {
            var data = await _repository.FindAsync(id);
            if (data is null) return NotFound();

            return data;
        }
        
        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> PostAsync([FromBody] Category category)
        {
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = category.Id }, category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Category category)
        {
            _repository.Update(category);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var data = _repository.Find(id);
            _repository.Delete(data);
            await _repository.SaveChangesAsync();
            return Ok();
        }
    }
}

using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EgeBilgiBilisimTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IRepository<Brand> _repository;

        public BrandsController(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        public async Task<IEnumerable<Brand>> GetAsync()
        {
            return await _repository.GetAllAsync();   
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetAsync(int id)
        {
            var data = await _repository.FindAsync(id);
            if (data is null) return NotFound();
            return data;
        }

        // POST api/<BrandsController>
        [HttpPost]
        public async Task<ActionResult<Brand>> PostAsync([FromBody] Brand brand)
        {
            await _repository.AddAsync(brand);
            await _repository.SaveChangesAsync();
            return CreatedAtAction("Get", new {id=brand.Id},brand);
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> PutAsync(int id, [FromBody] Brand brand)
        {
            _repository.Update(brand);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> DeleteAsync(int id)
        {
            var brand = _repository.Find(id);
            _repository.Delete(brand);
            await _repository.SaveChangesAsync();
            return Ok();
        }
    }
}

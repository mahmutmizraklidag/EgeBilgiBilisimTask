using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EgeBilgiBilisimTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly IRepository<Slider> _repository;

        public SlidersController(IRepository<Slider> repository)
        {
            _repository = repository;
        }
        // GET: api/<SlidersController>
        [HttpGet]
        public async Task<IEnumerable<Slider>> GetAsync()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/<SlidersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slider>> GetAsync(int id)
        {
            var data = await _repository.FindAsync(id);
            if (data is null) return NotFound();

            return data;
        }

        // POST api/<SlidersController>
        [HttpPost]
        public async Task<ActionResult<Slider>> PostAsync([FromBody] Slider slider)
        {
            await _repository.AddAsync(slider);
            await _repository.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = slider.Id }, slider);
        }

        // PUT api/<SlidersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Slider slider)
        {
            _repository.Update(slider);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<SlidersController>/5
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

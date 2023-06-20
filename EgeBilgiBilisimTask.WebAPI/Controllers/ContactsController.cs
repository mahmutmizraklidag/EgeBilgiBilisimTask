using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EgeBilgiBilisimTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository<Contact> _repository;

        public ContactsController(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        // GET: api/<ContactsController>
        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAsync()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetAsync(int id)
        {
            var data = await _repository.FindAsync(id);
            if (data is null) return NotFound();

            return data;
        }

        // POST api/<ContactsController>
        [HttpPost]
        public async Task<ActionResult<Contact>> PostAsync([FromBody] Contact contact)
        {
            await _repository.AddAsync(contact);
            await _repository.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = contact.Id }, contact);
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Contact contact)
        {
            _repository.Update(contact);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ContactsController>/5
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

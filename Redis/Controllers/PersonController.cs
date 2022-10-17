using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Redis.Entities;
using Redis.Infrastructure.Caching;
using Redis.Infrastructure.Repositories;
using Redis.Model;

namespace Redis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly ICachingService _cache;

        public PersonController(IPersonRepository repository, ICachingService cache)
        {
            _repository = repository;
            _cache = cache;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var personCache = await _cache.GetAsync(id.ToString());

            Person? person;

            if(!string.IsNullOrWhiteSpace(personCache))
            {
                person = JsonConvert.DeserializeObject<Person>(personCache);

                return Ok(person);
            }
             
            person = await _repository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            await _cache.SetAsync(id.ToString(), JsonConvert.SerializeObject(person));

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonInputModel model)
        {
            var person = new Person(model.Id, model.Name, model.Age, model.IsValid);
            await _repository.AddPerson(person);

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, model);
        }
    }
}

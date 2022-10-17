using Microsoft.EntityFrameworkCore;
using Redis.Entities;
using Redis.Infrastructure.Persistence;

namespace Redis.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _db;

        public PersonRepository(PersonDbContext db)
        {
            _db = db;
        }

        public async Task AddPerson(Person person)
        {
            await _db.Persons.AddAsync(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> GetById(int id)
        {
            var person = await _db.Persons.SingleOrDefaultAsync(x => x.Id == id);

            return person;
        }
    }
}

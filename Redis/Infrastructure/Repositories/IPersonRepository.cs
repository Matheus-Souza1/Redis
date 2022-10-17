using Redis.Entities;

namespace Redis.Infrastructure.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetById(int id);
        Task AddPerson(Person person);

    }
}

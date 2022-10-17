using Microsoft.EntityFrameworkCore;
using Redis.Entities;

namespace Redis.Infrastructure.Persistence
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options): base(options){}

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(x => x.Id);
        }
    }
}

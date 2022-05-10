using RRS.Data;
using RRS.Models;

namespace RRS.Services
{
    public class PersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Person FindOrCreatePerson<T>(PersonVM personVM)
            where T : Person, new()
        {
            var result = _context.People.Where(p => p.Email == personVM.Email).ToList();
            Person person;
            if (result.Count > 0)
            {
                person = (T)result.First();
                person.FirstName ??= personVM.FirstName;
                person.LastName ??= personVM.LastName;
                person.PhoneNumber ??= personVM.PhoneNumber;
                return person;
            }
            else
            {
                person = new T
                {
                    FirstName = personVM.FirstName,
                    LastName = personVM.LastName,
                    Email = personVM.Email,
                    PhoneNumber = personVM.PhoneNumber,
                    RestaurantId = personVM.RestaurantId
                };
                _context.People.Add(person);
                return person;
            }
        }
    }
}

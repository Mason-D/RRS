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

        public Object FindOrCreatePerson<T>(PersonVM personVM)
            where T : Person, new()
        {
            var result = _context.People.Where(p => p.Email == personVM.Email).ToList();
            Person person;
            if (result.Count > 0)
            {
                person = (T)result.First();
                return new { Person = person, WasCreated = false };
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
                return new { Person = person, WasCreated = true };
            }
        }

        public bool NamesAreValid(string firstName, string lastName)
        {
            return firstName != null && lastName != null;
        }
    }
}

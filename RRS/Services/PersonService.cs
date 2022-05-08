using RRS.Data;

namespace RRS.Services
{
    public class PersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }
         
        public Person FindOrCreatePerson<T>(string firstName, string lastName, string email, string phoneNumber, int restaurantId)
            where T : Person, new()
        {
            var result = _context.People.Where(p => p.Email == p.Email).ToList();

            return result.Count > 0 ?
                (T) result.First()
                : new T
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    RestaurantId = restaurantId
                };
        }
    }
}

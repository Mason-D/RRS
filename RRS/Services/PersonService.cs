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
         
        public Person FindOrCreatePerson<T>(string firstName, string lastName, string email, string? phoneNumber, int restaurantId)
            where T : Person, new()
        {
            bool namesMatch;
            var result = _context.People.Where(p => p.Email == email).ToList();
            var person = result.Count > 0 ? result.First() : null;

            if (person != null) // Existing person first & last name must match name arguments 
            {
                if (validNames(firstName, lastName, person))
                {
                    return person;
                }
                else
                {
                    throw new ArgumentException("First and/or last name doesn't match existing records with this email.");
                }
            }
            else // If a person doesn't exist, names matching validation not required.
            {
                person = new T
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    RestaurantId = restaurantId
                };
                return person;
            }

            // Previous code. Works.
            //var result = _context.People.Where(p => p.Email == email).ToList();

            //return result.Count > 0 ?
            //    (T) result.First()
            //    : new T
            //    {
            //        FirstName = firstName,
            //        LastName = lastName,
            //        Email = email,
            //        PhoneNumber = phoneNumber,
            //        RestaurantId = restaurantId
            //    };
        }

        private bool validNames(string firstName, string lastName, Person person)
        {
            return person.FirstName == firstName && person.LastName == lastName;
        }
    }
}

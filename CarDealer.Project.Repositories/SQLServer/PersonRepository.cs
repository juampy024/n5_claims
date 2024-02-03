using N5_API.Project.Models;
using N5_API.Project.Repositories.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Repositories.SQLServer
{
    public class PersonRepository : IPersonRepository
    {
        protected readonly N5Context _context;

        public PersonRepository(N5Context context)
        {
            _context = context;
        }
        public Task<Person> CreatePersonAsync(Person person)
        {
            try
            {
                if (person == null)
                {
                    throw new ArgumentNullException(nameof(person));
                }
                _context.Person.Add(person);
                _context.SaveChangesAsync();
                return Task.FromResult(person);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Person> GetPersonAsync(string id)
        {
            try 
            {
                var person = await _context.Person.FindAsync(id);

                if(person == null)
                {
                    throw new ArgumentNullException(nameof(person));
                }

                return person;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

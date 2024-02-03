using N5_API.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Repositories.SQLServer
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonAsync(string id);
        Task<Person> CreatePersonAsync(Person person);
    }
}

using Library.LMS.Models;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class PersonEC
    {
        public List<Person> GetPeople()
        {
            return DatabaseContext.People;
        }

        public Person AddOrUpdatePerson(Person p)
        {
            DatabaseContext.People.Add(p);
            return p;
        }
    }
}

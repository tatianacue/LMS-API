using Library.LMS.Models;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class PersonEC
    {
        public List<Person> GetPeople()
        {
            return FakeDatabaseContext.People;
        }

        public Person AddOrUpdatePerson(Person p)
        {
            if (p.IdNumber > 0)
            {
                var itemToUpdate = FakeDatabaseContext.People.FirstOrDefault(x => x.IdNumber == p.IdNumber);
                if (itemToUpdate != null) 
                {
                    FakeDatabaseContext.People.Remove(itemToUpdate); 
                    FakeDatabaseContext.People.Add(p);
                }
            }else
            {
                var lastId = FakeDatabaseContext.People.Select(x => x.IdNumber).Max();
                p.IdNumber = ++lastId;
                FakeDatabaseContext.People.Add(p);
            }
            return p;
        }
    }
}

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

        public void AddOrUpdatePerson(Person p)
        {
            if (p.IdNumber > 0)
            {
                var itemToUpdate = FakeDatabaseContext.People.FirstOrDefault(x => x.IdNumber == p.IdNumber);
                if (itemToUpdate != null) 
                {
                    FakeDatabaseContext.People.Remove(itemToUpdate); 
                    FakeDatabaseContext.People.Add(p);
                }
            }
            else
            {
                int lastId;
                if (FakeDatabaseContext.People.Count > 0)
                {
                    lastId = FakeDatabaseContext.People.Select(x => x.IdNumber).Max();
                }
                else
                {
                    lastId = 0;
                }
                p.IdNumber = ++lastId;
                FakeDatabaseContext.People.Add(p);
            }
        }
    }
}

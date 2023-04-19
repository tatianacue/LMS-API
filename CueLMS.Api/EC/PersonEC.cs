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
            if (p.IdNumber > 0)
            {
                var itemToUpdate = DatabaseContext.People.FirstOrDefault(x => x.IdNumber == p.IdNumber);
                if (itemToUpdate != null) 
                {
                    DatabaseContext.People.Remove(itemToUpdate); 
                    DatabaseContext.People.Add(p);
                }
            }else
            {
                var lastId = DatabaseContext.People.Select(x => x.IdNumber).Max();
                p.IdNumber = ++lastId;
                DatabaseContext.People.Add(p);
            }
            return p;
        }
    }
}

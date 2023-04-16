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
    }
}

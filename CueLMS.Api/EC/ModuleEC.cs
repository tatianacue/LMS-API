using Library.LMS.Models;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class ModuleEC
    {
        public List<Module> GetModules(int id)
        {
            var Course = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == id);
            if (Course == null)
            {
                Course = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == id);
            }
            if (Course == null)
            {
                Course = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == id);
            }
            if (Course != null)
            {
                return Course.Modules;
            }
            else
            {
                return new List<Module>();
            }
        }

        public void AddOrUpdateModule(Course c)
        {
            var Course = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == c.Id);
            if (Course == null)
            {
                Course = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == c.Id);
            }
            if (Course == null)
            {
                Course = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == c.Id);
            }
            if (Course != null)
            {
                var Module = c.SelectedModule;
                if (Module.Id > 0)
                {
                    var itemToUpdate = Course.Modules.FirstOrDefault(x => x.Id == Module.Id);
                    if (itemToUpdate != null)
                    {
                        Course.Modules.Remove(itemToUpdate);
                        Course.Modules.Add(Module);
                    }
                }
                else
                {
                    int lastId;
                    if (Course.Modules.Count > 0)
                    {
                        lastId = Course.Modules.Select(x => x.Id).Max();
                    }
                    else
                    {
                        lastId = 0;
                    }
                    Module.Id = ++lastId;
                    Course.Modules.Add(Module);
                }
            }
        }
        public void DeleteModule(Course c)
        {
            var Course = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == c.Id);
            if (Course == null)
            {
                Course = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == c.Id);
            }
            if (Course == null)
            {
                Course = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == c.Id);
            }
            if (Course != null)
            {
                var Module = c.SelectedModule;
                var item = Course.Modules.FirstOrDefault(x => x.Id == Module.Id);
                if (item != null)
                {
                    Course.Modules.Remove(item);
                }
            }
        }
    }
}

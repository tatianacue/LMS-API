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
                    if (FakeDatabaseContext.ModuleIds.Count > 0) //so module ids are unique
                    {
                        lastId = FakeDatabaseContext.ModuleIds.Max();
                    }
                    else
                    {
                        lastId = 0;
                    }
                    Module.Id = ++lastId;
                    Course.Modules.Add(Module);
                    FakeDatabaseContext.ModuleIds.Add(Module.Id);
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
        public List<ContentItem> GetContent(int id)
        {
            Module getfrom = new Module();
            int found = 0;
            foreach (var course in FakeDatabaseContext.SpringCourses) //fix this
            {
                foreach (var module in course.Modules)
                {
                    if (module.Id == id)
                    {
                        getfrom = module;
                        found = 1; break;
                    }
                }
            }
            if (found == 0)
            {
                foreach (var course in FakeDatabaseContext.SummerCourses)
                {
                    foreach (var module in course.Modules)
                    {
                        if (module.Id == id)
                        {
                            getfrom = module;
                            found = 1; break;
                        }
                    }
                }
            }
            if (found == 0)
            {
                foreach (var course in FakeDatabaseContext.FallCourses)
                {
                    foreach (var module in course.Modules)
                    {
                        if (module.Id == id)
                        {
                            getfrom = module;
                            found = 1; break;
                        }
                    }
                }
            }
            if (found == 1)
            {
                return getfrom.Content;
            }
            else
            {
                return new List<ContentItem>();
            }
        }
        public void AddUpdateContent(Course c)
        {
            var selectedmodule = c.SelectedModule;
            var item = c.SelectedItem;
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
                var module = Course.Modules.FirstOrDefault(x => x.Id == selectedmodule.Id);
                if (module != null)
                {
                    if (item.Id > 0)
                    {
                        var olditem = module.Content.FirstOrDefault(x => x.Id == item.Id);
                        if (olditem != null)
                        {
                            module.Content.Remove(olditem);
                            module.Content.Add(item);
                        }
                    }
                    else
                    {
                        int lastId;
                        if (module.Content.Count > 0)
                        {
                            lastId = module.Content.Select(x => x.Id).Max();
                        }
                        else
                        {
                            lastId = 0;
                        }
                        item.Id = ++lastId;
                        module.Content.Add(item);
                    }
                }
            }
        }
        public void RemoveContent(Course c)
        {
            var selectedmodule = c.SelectedModule;
            var item = c.SelectedItem;
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
                var module = Course.Modules.FirstOrDefault(x => x.Id == selectedmodule.Id); //module in database
                if (module != null)
                {
                    var removable = module.Content.FirstOrDefault(x => x.Id == item.Id); //actual item needed to be removed
                    module.Content.Remove(removable);
                }
            }
        }
    }
}

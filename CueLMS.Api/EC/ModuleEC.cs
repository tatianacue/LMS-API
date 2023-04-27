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
        public List<FileItem> GetFileItems(int id)
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
                return getfrom.FileItems;
            }
            else
            {
                return new List<FileItem>();
            }
        }
        public List<PageItem> GetPageItems(int id)
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
                return getfrom.PageItems;
            }
            else
            {
                return new List<PageItem>();
            }
        }
        public List<AssignmentItem> GetAssignmentItems(int id)
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
                return getfrom.AssignmentItems;
            }
            else
            {
                return new List<AssignmentItem>();
            }
        }
        public void AddUpdateFileItem(Course c)
        {
            var selectedmodule = c.SelectedModule;
            var item = c.SelectedFileItem;
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
                        var olditem = module.FileItems.FirstOrDefault(x => x.Id == item.Id);
                        if (olditem != null)
                        {
                            module.FileItems.Remove(olditem);
                            module.FileItems.Add(item);
                        }
                    }
                    else
                    {
                        int lastId;
                        if (FakeDatabaseContext.ContentItemIds.Count > 0)
                        {
                            lastId = FakeDatabaseContext.ContentItemIds.Max();
                        }
                        else
                        {
                            lastId = 0;
                        }
                        item.Id = ++lastId;
                        module.FileItems.Add(item);
                        FakeDatabaseContext.ContentItemIds.Add(item.Id);
                    }
                }
            }
        }
        public void AddUpdatePageItem(Course c)
        {
            var selectedmodule = c.SelectedModule;
            var item = c.SelectedPageItem;
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
                        var olditem = module.PageItems.FirstOrDefault(x => x.Id == item.Id);
                        if (olditem != null)
                        {
                            module.PageItems.Remove(olditem);
                            module.PageItems.Add(item);
                        }
                    }
                    else
                    {
                        int lastId;
                        if (FakeDatabaseContext.ContentItemIds.Count > 0)
                        {
                            lastId = FakeDatabaseContext.ContentItemIds.Max();
                        }
                        else
                        {
                            lastId = 0;
                        }
                        item.Id = ++lastId;
                        module.PageItems.Add(item);
                        FakeDatabaseContext.ContentItemIds.Add(item.Id);
                    }
                }
            }
        }
        public void AddUpdateAssignmentItem(Course c)
        {
            var selectedmodule = c.SelectedModule;
            var item = c.SelectedAssignmentItem;
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
                        var olditem = module.AssignmentItems.FirstOrDefault(x => x.Id == item.Id);
                        if (olditem != null)
                        {
                            module.AssignmentItems.Remove(olditem);
                            module.AssignmentItems.Add(item);
                        }
                    }
                    else
                    {
                        int lastId;
                        if (FakeDatabaseContext.ContentItemIds.Count > 0)
                        {
                            lastId = FakeDatabaseContext.ContentItemIds.Max();
                        }
                        else
                        {
                            lastId = 0;
                        }
                        item.Id = ++lastId;
                        module.AssignmentItems.Add(item);
                        FakeDatabaseContext.ContentItemIds.Add(item.Id);
                    }
                }
            }
        }
        public void RemoveFileItem(Course c)
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
                    var removable = module.FileItems.FirstOrDefault(x => x.Id == item.Id); //actual item needed to be removed
                    module.FileItems.Remove(removable);
                }
            }
        }
        public void RemovePageItem(Course c)
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
                    var removable = module.PageItems.FirstOrDefault(x => x.Id == item.Id); //actual item needed to be removed
                    module.PageItems.Remove(removable);
                }
            }
        }
        public void RemoveAssignmentItem(Course c)
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
                    var removable = module.AssignmentItems.FirstOrDefault(x => x.Id == item.Id); //actual item needed to be removed
                    module.AssignmentItems.Remove(removable);
                }
            }
        }
    }
}

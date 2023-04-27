using Library.LMS.Models;
using Library.LMS.Models.Grading;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class AssignmentGroupEC
    {
        public List<AssignmentGroup> GetGroups(int id)
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
                return Course.AssignmentGroups;
            }
            else { return new List<AssignmentGroup>(); }
        }
        public void AddOrUpdate(Course c)
        {
            var g = c.SelectedAssignmentGroup;
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
                if (g.Id > 0) //if group already exists, then add assignment to it
                {
                    var group = Course.AssignmentGroups.FirstOrDefault(x => x.Id == g.Id);
                    if (group != null)
                    {
                        group.Group.Add(c.SelectedAssignment);
                    }
                }
                else //add assignment group
                {
                    int lastId;
                    if (FakeDatabaseContext.AssignmentGroupIds.Count > 0)
                    {
                        lastId = FakeDatabaseContext.AssignmentGroupIds.Max();
                    }
                    else
                    {
                        lastId = 0;
                    }
                    g.Id = ++lastId;
                    g.Group.Add(c.SelectedAssignment); //adds assignment to group
                    Course.AssignmentGroups.Add(g); //adds group to group list
                    FakeDatabaseContext.AssignmentGroupIds.Add(g.Id); //adds id to used id list
                }
            }
        }
        public List<Assignment> GetAssignments(int id)
        {
            AssignmentGroup getfrom = new AssignmentGroup();
            int found = 0; //finding what course and group the list is from
            foreach (var course in FakeDatabaseContext.SpringCourses)
            {
                foreach (var group in course.AssignmentGroups)
                {
                    if (group.Id == id)
                    {
                        getfrom = group;
                        found = 1; break;
                    }
                }
            }
            if (found == 0)
            {
                foreach (var course in FakeDatabaseContext.SummerCourses)
                {
                    foreach (var group in course.AssignmentGroups)
                    {
                        if (group.Id == id)
                        {
                            getfrom = group;
                            found = 1; break;
                        }
                    }
                }
            }
            if (found == 0)
            {
                foreach (var course in FakeDatabaseContext.FallCourses)
                {
                    foreach (var group in course.AssignmentGroups)
                    {
                        if (group.Id == id)
                        {
                            getfrom = group;
                            found = 1; break;
                        }
                    }
                }
            }
            if (found == 1)
            {
                return getfrom.Group; //list of assignments
            }
            else
            {
                return new List<Assignment>();
            }
        }
    }
}

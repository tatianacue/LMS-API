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
                    if (Course.AssignmentGroups.Count > 0)
                    {
                        lastId = Course.AssignmentGroups.Select(x => x.Id).Max();
                    }
                    else
                    {
                        lastId = 0;
                    }
                    g.Id = ++lastId;
                    g.Group.Add(c.SelectedAssignment); //adds assignment to group
                    Course.AssignmentGroups.Add(g); //adds group to group list
                }
            }
        }
    }
}

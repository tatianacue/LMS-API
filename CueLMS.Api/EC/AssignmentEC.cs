using Library.LMS.Models;
using UWP.Library.CueLMS.Database;
/* Tatiana Graciela Cue COP4870-0001*/
namespace CueLMS.Api.EC
{
    public class AssignmentEC
    {
        public List<Assignment> GetAssignments(int id)
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
                return Course.Assignments;
            }
            else
            {
                return new List<Assignment>();
            }
        }

        public void AddOrUpdateAssignment(Course c)
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
                var assignment = c.SelectedAssignment;
                if (assignment.Id > 0)
                {
                    var itemToUpdate = Course.Assignments.FirstOrDefault(x => x.Id == assignment.Id);
                    if (itemToUpdate != null)
                    {
                        Course.Assignments.Remove(itemToUpdate);
                        Course.Assignments.Add(assignment);
                    }
                }
                else
                {
                    int lastId;
                    if (Course.Assignments.Count > 0)
                    {
                        lastId = Course.Assignments.Select(x => x.Id).Max();
                    }
                    else
                    {
                        lastId = 0;
                    }
                    assignment.Id = ++lastId;
                    Course.Assignments.Add(assignment);
                }
            }
        }
        public void DeleteAssignment(Course c)
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
                var assignment = c.SelectedAssignment;
                var item = Course.Assignments.FirstOrDefault(x => x.Id == assignment.Id);
                if (item != null)
                {
                    Course.Assignments.Remove(item);
                }
            }
        }
    }
}

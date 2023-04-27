using Library.LMS.Models;
using Library.LMS.Models.Grading;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class SubmissionEC
    {
        public List<Submission> GetSubmissions(int id)
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
                return Course.Submissions;
            }
            else
            {
                return new List<Submission>();
            }
        }

        public void AddOrUpdateSubmission(Course c)
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
                var Submission = c.SelectedSubmission;
                if (Submission.Id > 0)
                {
                    var itemToUpdate = Course.Submissions.FirstOrDefault(x => x.Id == Submission.Id);
                    if (itemToUpdate != null)
                    {
                       itemToUpdate.Grade = Submission.Grade;
                    }
                }
                else
                {
                    int lastId;
                    if (Course.Submissions.Count > 0)
                    {
                        lastId = Course.Submissions.Select(x => x.Id).Max();
                    }
                    else
                    {
                        lastId = 0;
                    }
                    Submission.Id = ++lastId;
                    Course.Submissions.Add(Submission);
                }
            }
        }
    }
}

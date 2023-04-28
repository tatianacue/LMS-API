using Library.LMS.Models;
using UWP.Library.CueLMS.Database;

namespace CueLMS.Api.EC
{
    public class PersonEC
    {
        public List<Student> GetStudents()
        {
            return FakeDatabaseContext.Students;
        }
        public List<TeachingAssistant> GetTeachingAssistants()
        {
            return FakeDatabaseContext.TeachingAssistants;
        }
        public List<Instructor> GetInstructors()
        {
            return FakeDatabaseContext.Instructors;
        }

        public void AddOrUpdateStudent(Student p)
        {
            if (p.IdNumber > 0)
            {
                var itemToUpdate = FakeDatabaseContext.Students.FirstOrDefault(x => x.IdNumber == p.IdNumber);
                if (itemToUpdate != null) 
                {
                    FakeDatabaseContext.Students.Remove(itemToUpdate); 
                    FakeDatabaseContext.Students.Add(p);
                }
            }
            else
            {
                int lastId;
                if (FakeDatabaseContext.PersonIds.Count > 0)
                {
                    lastId = FakeDatabaseContext.PersonIds.Max();
                }
                else
                {
                    lastId = 0;
                }
                p.IdNumber = ++lastId;
                FakeDatabaseContext.Students.Add(p);
                FakeDatabaseContext.PersonIds.Add(p.IdNumber);
            }
        }
        public void AddOrUpdateTA(TeachingAssistant p)
        {
            if (p.IdNumber > 0)
            {
                var itemToUpdate = FakeDatabaseContext.TeachingAssistants.FirstOrDefault(x => x.IdNumber == p.IdNumber);
                if (itemToUpdate != null)
                {
                    FakeDatabaseContext.TeachingAssistants.Remove(itemToUpdate);
                    FakeDatabaseContext.TeachingAssistants.Add(p);
                }
            }
            else
            {
                int lastId;
                if (FakeDatabaseContext.PersonIds.Count > 0)
                {
                    lastId = FakeDatabaseContext.PersonIds.Max();
                }
                else
                {
                    lastId = 0;
                }
                p.IdNumber = ++lastId;
                FakeDatabaseContext.TeachingAssistants.Add(p);
                FakeDatabaseContext.PersonIds.Add(p.IdNumber);
            }
        }
        public void AddOrUpdateInstructor(Instructor p)
        {
            if (p.IdNumber > 0)
            {
                var itemToUpdate = FakeDatabaseContext.Instructors.FirstOrDefault(x => x.IdNumber == p.IdNumber);
                if (itemToUpdate != null)
                {
                    FakeDatabaseContext.Instructors.Remove(itemToUpdate);
                    FakeDatabaseContext.Instructors.Add(p);
                }
            }
            else
            {
                int lastId;
                if (FakeDatabaseContext.PersonIds.Count > 0)
                {
                    lastId = FakeDatabaseContext.PersonIds.Max();
                }
                else
                {
                    lastId = 0;
                }
                p.IdNumber = ++lastId;
                FakeDatabaseContext.Instructors.Add(p);
                FakeDatabaseContext.PersonIds.Add(p.IdNumber);
            }
        }
        public Dictionary<Course, double> GetStudentGrades(int id)
        {
           var student = FakeDatabaseContext.Students.FirstOrDefault(x => x.IdNumber == id);
            if (student != null)
            {
                return student.Grades;
            }
            else
            {
                return new Dictionary<Course, double>();
            }
        }

        public void AddOrUpdateGrade(Student student)
        {
            var c = student.TempCourse;
            var g = student.TempGrade;
            var updateStudent = FakeDatabaseContext.Students.FirstOrDefault(x => x.IdNumber == student.IdNumber);
            if (updateStudent != null)
            {
                var course = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == c.Id);
                if (course == null) 
                {
                    course = FakeDatabaseContext.SummerCourses.FirstOrDefault(x => x.Id == c.Id);
                }
                if (course == null)
                {
                    course = FakeDatabaseContext.FallCourses.FirstOrDefault(x => x.Id == c.Id);
                }
                if (course != null)
                {
                    updateStudent.Grades[course] = g; //sets course and grade
                }
            }
        }
    }
}

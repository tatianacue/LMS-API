﻿using Library.LMS.Models;
using UWP.Library.CueLMS.Database;
/* Tatiana Graciela Cue COP4870-0001*/
namespace CueLMS.Api.EC
{
    public class SpringCoursesEC
    {
        public List<Course> GetCourses()
        {
            return FakeDatabaseContext.SpringCourses;
        }

        public void AddOrUpdateCourse(Course c)
        {
            if (c.Id > 0)
            {
                var itemToUpdate = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == c.Id);
                if (itemToUpdate != null)
                {
                    FakeDatabaseContext.SpringCourses.Remove(itemToUpdate);
                    FakeDatabaseContext.SpringCourses.Add(c);
                }
            }
            else
            {
                int lastId;
                if (FakeDatabaseContext.CourseIds.Count == 0)
                {
                    lastId = 0;
                }
                else
                {
                    lastId = FakeDatabaseContext.CourseIds.Max();
                } 
                c.Id = ++lastId;
                FakeDatabaseContext.SpringCourses.Add(c);
                FakeDatabaseContext.CourseIds.Add(c.Id); //adds to course id database
            }
        }
        public void DeleteCourse(Course c)
        {
            var item = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == c.Id);
            if (item != null)
            {
                FakeDatabaseContext.SpringCourses.Remove(item);
            }
        }
        public List<Student> GetRoster(int id)
        {
            var course = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == id); //course that matches
            if (course != null)
            {
                return course.Roster;
            }
            else { return new List<Student>(); }
        }
        public void AddToRoster(Course c)
        {
            var course = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == c.Id);
            if (course != null)
            {
                course.Roster.Add(c.SelectedStudent);
            }
        }
        public void RemoveFromRoster(Course c)
        {
            var course = FakeDatabaseContext.SpringCourses.FirstOrDefault(x => x.Id == c.Id);
            if (course != null)
            {
                var selected = c.SelectedStudent;
                var student = course.Roster.FirstOrDefault(x => x.IdNumber == selected.IdNumber);
                if (student != null)
                {
                    course.Roster.Remove(student);
                }
            }
        }
    }
}

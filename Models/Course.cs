using System.ComponentModel.DataAnnotations;

namespace SchoolWebApp.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<TeacherCourses> TeacherCourses { get; set; }
    }
}
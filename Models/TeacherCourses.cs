using System.ComponentModel.DataAnnotations;

namespace SchoolWebApp.Models
{
    public class TeacherCourses
    {
        [Key]
        public int TeacherCoursesID { get; set; }
        public int CourseID { get; set; }
        public int TeacherID { get; set; }

        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
    }
}
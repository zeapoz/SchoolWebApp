using System.ComponentModel.DataAnnotations;

namespace SchoolWebApp.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        
        public string FullName
        {
            get { return FirstMidName[0] + ". " + LastName; }
        }

        public ICollection<TeacherCourses> TeacherCourses { get; set; }
    }
}
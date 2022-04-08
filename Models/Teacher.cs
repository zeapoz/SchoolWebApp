using System.ComponentModel.DataAnnotations;

namespace SchoolWebApp.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        
        public string FullName
        {
            get { return FirstMidName[0] + ". " + LastName; }
        }

        public ICollection<TeacherCourses> TeacherCourses { get; set; }
    }
}
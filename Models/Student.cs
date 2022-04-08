using System.ComponentModel.DataAnnotations;

namespace SchoolWebApp.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
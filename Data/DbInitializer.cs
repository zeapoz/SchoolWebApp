using SchoolWebApp.Models;

namespace SchoolWebApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{ID=111111,FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{ID=111112,FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{ID=111113,FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{ID=111114,FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{ID=111115,FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{ID=111116,FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{ID=111117,FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{ID=111118,FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3},
                new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
                new Course{CourseID=1045,Title="Calculus",Credits=4},
                new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                new Course{CourseID=2021,Title="Composition",Credits=3},
                new Course{CourseID=2042,Title="Literature",Credits=4}
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var teachers = new Teacher[]
            {
                new Teacher{FirstMidName="John",LastName="Smith"},
                new Teacher{FirstMidName="Emily",LastName="Patrickson"},
            };

            context.Teachers.AddRange(teachers);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=111111,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=111111,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=111111,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=111112,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=111112,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=111112,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=111113,CourseID=1050},
                new Enrollment{StudentID=111114,CourseID=1050},
                new Enrollment{StudentID=111114,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=111115,CourseID=4041,Grade=Grade.C},
                new Enrollment{StudentID=111116,CourseID=1045},
                new Enrollment{StudentID=111117,CourseID=3141,Grade=Grade.A},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();

            var teacherCourses = new TeacherCourses[]
            {
                new TeacherCourses{CourseID=1050,TeacherID=1},
                new TeacherCourses{CourseID=4022,TeacherID=1},
                new TeacherCourses{CourseID=4041,TeacherID=2},
                new TeacherCourses{CourseID=1045,TeacherID=1},
                new TeacherCourses{CourseID=3141,TeacherID=1},
                new TeacherCourses{CourseID=2021,TeacherID=2},
                new TeacherCourses{CourseID=2042,TeacherID=1},
                new TeacherCourses{CourseID=2042,TeacherID=2},
                new TeacherCourses{CourseID=4041,TeacherID=1},
            };

            context.TeacherCourses.AddRange(teacherCourses);
            context.SaveChanges();
        }
    }
}
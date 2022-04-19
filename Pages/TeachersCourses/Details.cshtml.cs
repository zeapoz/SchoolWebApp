using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace SchoolWebApp.Pages.TeachersCourses
{
    [Authorize(Policy = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly SchoolWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(SchoolWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TeacherCourses TeacherCourses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeacherCourses = await _context.TeacherCourses
                .Include(t => t.Course)
                .Include(t => t.Teacher).FirstOrDefaultAsync(m => m.TeacherCoursesID == id);

            if (TeacherCourses == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

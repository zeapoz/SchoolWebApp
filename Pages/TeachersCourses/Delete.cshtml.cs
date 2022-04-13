using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Models;

namespace SchoolWebApp.Pages.TeachersCourses
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolWebApp.Data.ApplicationDbContext _context;

        public DeleteModel(SchoolWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeacherCourses = await _context.TeacherCourses.FindAsync(id);

            if (TeacherCourses != null)
            {
                _context.TeacherCourses.Remove(TeacherCourses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

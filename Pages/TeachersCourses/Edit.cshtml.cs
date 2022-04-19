using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace SchoolWebApp.Pages.TeachersCourses
{
    [Authorize(Policy = "Admin")]
    public class EditModel : PageModel
    {
        private readonly SchoolWebApp.Data.ApplicationDbContext _context;

        public EditModel(SchoolWebApp.Data.ApplicationDbContext context)
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
           ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
           ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TeacherCourses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherCoursesExists(TeacherCourses.TeacherCoursesID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TeacherCoursesExists(int id)
        {
            return _context.TeacherCourses.Any(e => e.TeacherCoursesID == id);
        }
    }
}

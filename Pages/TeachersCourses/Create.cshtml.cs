using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolWebApp.Data;
using SchoolWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace SchoolWebApp.Pages.TeachersCourses
{
    [Authorize(Policy = "Teacher")]
    public class CreateModel : PageModel
    {
        private readonly SchoolWebApp.Data.ApplicationDbContext _context;

        public CreateModel(SchoolWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
        ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID");
            return Page();
        }

        [BindProperty]
        public TeacherCourses TeacherCourses { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TeacherCourses.Add(TeacherCourses);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Courses/Index");
        }
    }
}

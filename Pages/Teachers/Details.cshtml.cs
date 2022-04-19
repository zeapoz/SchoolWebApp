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

namespace SchoolWebApp.Pages.Teachers
{
    [Authorize(Policy = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly SchoolWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(SchoolWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.TeacherID == id);

            if (Teacher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

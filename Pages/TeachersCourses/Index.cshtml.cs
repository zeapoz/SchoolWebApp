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
    public class IndexModel : PageModel
    {
        private readonly SchoolWebApp.Data.ApplicationDbContext _context;

        public IndexModel(SchoolWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TeacherCourses> TeacherCourses { get;set; }

        public async Task OnGetAsync()
        {
            TeacherCourses = await _context.TeacherCourses
                .Include(t => t.Course)
                .Include(t => t.Teacher).ToListAsync();
        }
    }
}

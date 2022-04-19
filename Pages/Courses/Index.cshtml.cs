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

namespace SchoolWebApp.Pages.Courses
{
    [Authorize(Policy = "Teacher")]
    public class IndexModel : PageModel
    {
        private readonly SchoolWebApp.Data.ApplicationDbContext _context;

        public IndexModel(SchoolWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
        }
    }
}

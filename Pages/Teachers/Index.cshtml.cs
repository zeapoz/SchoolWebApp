using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Models;

namespace SchoolWebApp.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly SchoolWebApp.Data.SchoolContext _context;

        public IndexModel(SchoolWebApp.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Teacher> Teacher { get;set; }

        public async Task OnGetAsync()
        {
            Teacher = await _context.Teachers.ToListAsync();
        }
    }
}

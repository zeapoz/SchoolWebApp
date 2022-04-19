using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Models;
using SchoolWebApp.Utility;
using Microsoft.AspNetCore.Authorization;

namespace SchoolWebApp.Pages.Students
{
    [Authorize(Policy = "Teacher")]
    public class IndexModel : PageModel
    {
        private readonly SchoolWebApp.Data.ApplicationDbContext _context;

        public IndexModel(SchoolWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable<Student> studentsIQ = from s in _context.Students select s;

            switch (sortOrder) {
                case "name_desc":
                    Student = Sorting.BubbleSort(studentsIQ).ToList();
                    break;
                default:
                    Student = await studentsIQ.AsNoTracking().ToListAsync();
                    break;
            }
        }
    }
}

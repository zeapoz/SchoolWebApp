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

namespace SchoolWebApp.Pages.Teachers
{
    [Authorize(Policy = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly SchoolWebApp.Data.ApplicationDbContext _context;

        public CreateModel(SchoolWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Teachers.Add(Teacher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

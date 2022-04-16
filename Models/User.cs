using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string SchoolID { get; set; }
    }
}
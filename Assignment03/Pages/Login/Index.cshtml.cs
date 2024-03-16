using Assignment03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment03.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Assignment3Context _context;
        public IndexModel(PRN221_Assignment3Context context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string username, string password) { 
            AppUser user = _context.AppUsers.Where(u => u.Email == username).FirstOrDefault();
            if (user == null || user.Password != password) { 
                // Redirect back to the login page
                return Page();
            }
            return RedirectToPage("/Posts/Index", new { userId = user.UserId });
        }
    }
}

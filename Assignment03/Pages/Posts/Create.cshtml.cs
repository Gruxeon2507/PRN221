using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment03.Models;
using Microsoft.AspNetCore.SignalR;
using Assignment03.Hubs;

namespace Assignment03.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly Assignment03.Models.PRN221_Assignment3Context _context;
        private readonly IHubContext<PostHubs> _signalRHub;
        public CreateModel(Assignment03.Models.PRN221_Assignment3Context context, IHubContext<PostHubs> hubContext)
        {
            _context = context;
            _signalRHub = hubContext;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorId"] = new SelectList(_context.AppUsers, "UserId", "UserId");
        ViewData["CategoryId"] = new SelectList(_context.PostCategories, "CategoryId", "CategoryId");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Posts == null || Post == null)
            {
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("LoadPost");
            return RedirectToPage("./Index");
        }
    }
}

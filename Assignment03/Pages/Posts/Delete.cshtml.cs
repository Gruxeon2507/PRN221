using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment03.Models;
using Assignment03.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Assignment03.Pages.Posts
{
    public class DeleteModel : PageModel
    {
        private readonly Assignment03.Models.PRN221_Assignment3Context _context;
        private readonly IHubContext<PostHubs> _signalRHub;
        public DeleteModel(Assignment03.Models.PRN221_Assignment3Context context, IHubContext<PostHubs> hubContext)
        {
            _context = context;
            _signalRHub = hubContext;
        }

        [BindProperty]
      public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FirstOrDefaultAsync(m => m.PostId == id);

            if (post == null)
            {
                return NotFound();
            }
            else 
            {
                Post = post;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);

            if (post != null)
            {
                Post = post;
                _context.Posts.Remove(Post);
                await _context.SaveChangesAsync();
            }
            await _signalRHub.Clients.All.SendAsync("LoadPost");
            return RedirectToPage("./Index");
        }
    }
}

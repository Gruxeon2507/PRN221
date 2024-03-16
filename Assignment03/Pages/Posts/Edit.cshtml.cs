using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment03.Models;
using Assignment03.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Assignment03.Pages.Posts
{
    public class EditModel : PageModel
    {
        private readonly Assignment03.Models.PRN221_Assignment3Context _context;
        private readonly IHubContext<PostHubs> _signalRHub;
        public EditModel(Assignment03.Models.PRN221_Assignment3Context context, IHubContext<PostHubs> hubContext)
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

            var post =  await _context.Posts.FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            Post = post;
           ViewData["AuthorId"] = new SelectList(_context.AppUsers, "UserId", "UserId");
           ViewData["CategoryId"] = new SelectList(_context.PostCategories, "CategoryId", "CategoryId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.PostId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await _signalRHub.Clients.All.SendAsync("LoadPost");
            return RedirectToPage("./Index");
        }

        private bool PostExists(int id)
        {
          return (_context.Posts?.Any(e => e.PostId == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment03.Models;
using System.Xml.Linq;

namespace Assignment03.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly Assignment03.Models.PRN221_Assignment3Context _context;
        public string UserId;
        public IndexModel(Assignment03.Models.PRN221_Assignment3Context context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;
        public IList<Post> Posts { get;set; } = default!;
        public int PageSize { get; private set; } = 6; // Number of items per page
        public int TotalPages { get; private set; }
        public int CurrentPage { get; private set; } = 1;
        public int Page = 1;
        public string SearchInput;
        public async Task OnGetAsync(string searchInput)
        {
            if (!string.IsNullOrEmpty(searchInput))
            {
                // Search by PostId or Title
                Posts = await _context.Posts
                    .Include(p => p.Author)
                    .Include(p => p.Category)
                    .Where(p => p.PostId.ToString() == searchInput || p.Title.Contains(searchInput))
                    .ToListAsync();
                SearchInput = searchInput;

            }
            else
            {
                if (_context.Posts != null)
                {
                    Posts = await _context.Posts
                    .Include(p => p.Author)
                    .Include(p => p.Category).ToListAsync();
                }
            }
            if (Request.Query.ContainsKey("page") && int.TryParse(Request.Query["page"], out int page))
            {
                Page = page;
            }
            else
            {
                Page = 1; // Default to page 1 if no page parameter is provided or if it's invalid
            }
 

            CurrentPage = Page == 0? 1: Page;
            TotalPages = TotalPages = (int)Math.Ceiling(Posts.Count / (double)PageSize);
            CurrentPage = CurrentPage < 1 ? 1 : (CurrentPage > TotalPages ? TotalPages : CurrentPage);
            Post = Posts.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}

using Fall23B5_Q2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Fall23B5_Q2.Pages.Student
{
    public class ListModel : PageModel
    {
        private readonly PE_PRN221_Fall23B5Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHubContext<SignalRHub> _signalRHub;
        public ListModel(PE_PRN221_Fall23B5Context context, 
            IHttpContextAccessor httpContextAccessor,
            IHubContext<SignalRHub> hubContext)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _signalRHub = hubContext;
        }

        [BindProperty(SupportsGet = true)]
        public string? MajorFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GenderFilter { get; set; }

        [BindProperty]
        public List<Major> Majors { get; set; }

        [BindProperty]

        public List<Models.Student> Students { get; set; }

        public async Task OnGet(string? major, bool? gender, string? sortby)
        {
            try
            {
                //var session = _httpContextAccessor.HttpContext.Session;
                Majors = await _context.Majors.ToListAsync();
                Students = await _context.Students.ToListAsync();

                if (!string.IsNullOrEmpty(major))
                {
                    Students = Students.Where(x => x.Major.Equals(major)).ToList();
                    //session.Remove("searchMajor");
                    //session.SetString("searchMajor", major);
                }
                //MajorFilter = session.GetString("searchMajor" ?? "");
                if (gender != null)
                {
                    Students = Students.Where(x => x.Male == gender).ToList();
                }
                if (!string.IsNullOrEmpty(sortby))
                {
                    if (sortby.Equals("StudentName"))
                    {
                        Students = Students.OrderBy(x => x.FullName).ToList();
                    }
                    if (sortby.Equals("StudentId"))
                    {
                        Students = Students.OrderBy(x => x.StudentId).ToList();
                    }
                    if (sortby.Equals("StudentDob"))
                    {
                        Students = Students.OrderBy(x => x.Dob).ToList();
                    }
                }

                MapStudents(Students);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
                if (student == null)
                {
                    return NotFound("khong tim thay");
                }
                _context.Remove(student);
                await _context.SaveChangesAsync();
                await _signalRHub.Clients.All.SendAsync("LoadStudent");
                return RedirectToPage("./List");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void MapStudents(List<Models.Student> result)
        {
            foreach (var student in result)
            {
                if (!string.IsNullOrEmpty(student.Major) && student.Major.Equals("AI"))
                {
                    student.Major = "Artificial Intelligence";
                }
                if (!string.IsNullOrEmpty(student.Major) && student.Major.Equals("GD"))
                {
                    student.Major = "Graphic Design";
                }
                if (!string.IsNullOrEmpty(student.Major) && student.Major.Equals("IA"))
                {
                    student.Major = "Information Assurance";
                }
                if (!string.IsNullOrEmpty(student.Major) && student.Major.Equals("SE"))
                {
                    student.Major = "Software Engineering";
                }
            }
        }
    }
}

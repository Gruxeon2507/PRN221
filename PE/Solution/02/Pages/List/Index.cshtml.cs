using _02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace _02.Pages.List
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Spr22Context _context;
        public string Room { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        public IndexModel(PRN221_Spr22Context context)
        {
            _context = context;
        }
        public void OnGet(string room)
        {
            Room = room;
            if (String.IsNullOrEmpty(room))
            {
                var currentMonth = DateTime.Now.Month;
                Services = _context.Services.Include(x => x.EmployeeNavigation).Where(x => x.Month == currentMonth).ToList();

            }
            else
            {
                Services = _context.Services.Include(x => x.EmployeeNavigation).Where(x => x.RoomTitle.Contains(Room)).ToList();
            }
        }

        public void OnPost(IFormFile inputfile)
        {
            string fileContent = string.Empty;
            using (var reader = new StreamReader(inputfile.OpenReadStream()))
            {
                fileContent = reader.ReadToEnd();
            }
            if(!string.IsNullOrEmpty(fileContent))
            {
                var listOfService = JsonConvert.DeserializeObject<List<Service>>(fileContent);
                if (listOfService.Count > 0)
                {
                    foreach(var service in listOfService)
                    {
                        service.Id = 0;
                    }
                }
                _context.Services.AddRange(listOfService);
                _context.SaveChanges();
            }
            Services = _context.Services.Include(x => x.EmployeeNavigation).ToList();
        }
    }
}

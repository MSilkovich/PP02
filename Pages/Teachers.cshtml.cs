//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using VisitkaUCR.Models;

//namespace VisitkaUCR.Pages
//{
//    public class TeachersModel : PageModel
//    {
//        private readonly VisitkaUCR.Models.PostgresContext _context;

//        public TeachersModel(VisitkaUCR.Models.PostgresContext context)
//        {
//            _context = context;
//        }

//        public IActionResult OnGet()
//        {
//            return Page();
//        }

//        [BindProperty]
//        public Teacher Teacher { get; set; } = default!;

//        // For more information, see https://aka.ms/RazorPagesCRUD.
//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.Teachers.Add(Teacher);
//            await _context.SaveChangesAsync();

//            return RedirectToPage("./Index");
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisitkaUCR.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitkaUCR.Pages
{
    public class TeachersModel : PageModel
    {
        private readonly PostgresContext _context;

        public TeachersModel(PostgresContext context)
        {
            _context = context;
        }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<string> Positions { get; set; } = new List<string>();
        public List<string> Faculties { get; set; } = new List<string>();
        public List<string> Divisions { get; set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync()
        {
            Teachers = await _context.Teachers
                .Include(t => t.IdPositions)
                    .ThenInclude(p => p.IdDivisionNavigation)
                    .ThenInclude(d => d.IdFacultyNavigation)
                .Include(t => t.TeachersDisciplines)
                    .ThenInclude(td => td.IdDisciplineNavigation)
                .Include(t => t.IdAchievements)
                .Include(t => t.IdPublications)
                .ToListAsync();

            Positions = await _context.Positions.Select(p => p.Title).Distinct().ToListAsync();
            Faculties = await _context.Faculties.Select(f => f.Title).Distinct().ToListAsync();
            Divisions = await _context.Divisions.Select(d => d.Title).Distinct().ToListAsync();

            return Page();
        }
    }
}

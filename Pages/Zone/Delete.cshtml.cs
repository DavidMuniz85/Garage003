using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage003.Data;
using Garage003.Models;

namespace Garage003.Pages.Zone
{
    public class DeleteModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;

        public DeleteModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Zone Zone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zone == null)
            {
                return NotFound();
            }

            var zone = await _context.Zone.FirstOrDefaultAsync(m => m.ZoneId == id);

            if (zone == null)
            {
                return NotFound();
            }
            else 
            {
                Zone = zone;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Zone == null)
            {
                return NotFound();
            }
            var zone = await _context.Zone.FindAsync(id);

            if (zone != null)
            {
                Zone = zone;
                _context.Zone.Remove(Zone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

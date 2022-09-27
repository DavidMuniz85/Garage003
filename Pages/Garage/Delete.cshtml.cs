using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage003.Data;
using Garage003.Models;

namespace Garage003.Pages.Garage
{
    public class DeleteModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;

        public DeleteModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Garage Garage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Garage == null)
            {
                return NotFound();
            }

            var garage = await _context.Garage.FirstOrDefaultAsync(m => m.GarageId == id);

            if (garage == null)
            {
                return NotFound();
            }
            else 
            {
                Garage = garage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Garage == null)
            {
                return NotFound();
            }
            var garage = await _context.Garage.FindAsync(id);

            if (garage != null)
            {
                Garage = garage;
                _context.Garage.Remove(Garage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

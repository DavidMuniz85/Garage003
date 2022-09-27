using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage003.Data;
using Garage003.Models;

namespace Garage003.Pages.Garage
{
    public class EditModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;

        public EditModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Garage Garage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Garage == null)
            {
                return NotFound();
            }

            var garage =  await _context.Garage.FirstOrDefaultAsync(m => m.GarageId == id);
            if (garage == null)
            {
                return NotFound();
            }
            Garage = garage;
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

            _context.Attach(Garage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarageExists(Garage.GarageId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GarageExists(int id)
        {
          return _context.Garage.Any(e => e.GarageId == id);
        }
    }
}

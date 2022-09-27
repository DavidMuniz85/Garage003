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
    public class DetailsModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;

        public DetailsModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}

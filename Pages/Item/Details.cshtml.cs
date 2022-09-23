using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage003.Data;
using Garage003.Models;

namespace Garage003.Pages.Item
{
    public class DetailsModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;

        public DetailsModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Models.Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }
            else 
            {
                Item = item;
            }
            return Page();
        }
    }
}

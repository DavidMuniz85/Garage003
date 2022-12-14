using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Garage003.Data;
using Garage003.Models;

namespace Garage003.Pages.Status
{
    public class CreateModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;

        public CreateModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Status Status { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Status.Add(Status);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

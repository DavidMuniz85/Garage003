﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage003.Data;
using Garage003.Models;

namespace Garage003.Pages.Status
{
    public class EditModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;

        public EditModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Status Status { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status =  await _context.Status.FirstOrDefaultAsync(m => m.StatusId == id);
            if (status == null)
            {
                return NotFound();
            }
            Status = status;
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

            _context.Attach(Status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(Status.StatusId))
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

        private bool StatusExists(int id)
        {
          return _context.Status.Any(e => e.StatusId == id);
        }
    }
}

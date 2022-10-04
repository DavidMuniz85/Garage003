using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Garage003.Data;
using Garage003.Models;

namespace Garage003.Pages.Item
{
    public class CreateModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Statuses { get; set; }

        public CreateModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string categoryId)
        {
            Categories = _context.Category.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.CategoryId.ToString(),
                                      Text = a.CategoryName
                                  }).ToList();
            Statuses = _context.Status.Select(s =>
                                  new SelectListItem
                                  {
                                      Value = s.StatusId.ToString(),
                                      Text = s.StatusName
                                  }).ToList();
            return Page();
        }

        [BindProperty]
        public Models.Item Item { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string categoryId, string statusId)
        {
            int x = Convert.ToInt16(categoryId);
            int y = Convert.ToInt16(statusId);

            Item.CategoryId = x;
            Item.StatusId = y;

            Models.Category cat = new Models.Category();
            cat = _context.Category.Find(x);
            Item.Category = cat;
            Models.Status status = new Models.Status();
            status = _context.Status.Find(y);
            Item.Status = status;


            _context.Item.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

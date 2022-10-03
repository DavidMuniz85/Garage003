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
            //View Data que regresa Categorias
            ViewData["Categorias"] = new SelectList(_context.Category.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.CategoryId.ToString(),
                                      Text = a.CategoryName
                                  }).ToList());
            return Page();
        }

        [BindProperty]
        public Models.Item Item { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string categoryId)
        {
            int x = Convert.ToInt16(categoryId);
            
            Item.CategoryId = x;
            Models.Category cat = new Models.Category();
            cat = _context.Category.Find(x);
            Item.Category = cat;
            
            //if (!ModelState.IsValid)
            //{
            //    var errorList = new List<string>();
            //    List<string> keys = ModelState.Keys.ToList();
            //    foreach (string key in keys)
            //    {
            //        var errors = ModelState[key].Errors.ToList();
            //        errors.ForEach(x => { errorList.Add(x.ErrorMessage); });
            //    }
            //    return Page();
            //}

            _context.Item.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

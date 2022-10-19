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
        private readonly ApplicationDbContext _context;
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Statuses { get; set; }
        public List<SelectListItem> Zones { get; set; }


        public CreateModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //public IActionResult OnGet(string categoryId)
        public IActionResult OnGet()
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
            Zones = _context.Zone.Select(s =>
                                  new SelectListItem
                                  {
                                      Value = s.ZoneId.ToString(),
                                      Text= s.ZoneName
                                  }).ToList();
            return Page();
        }

        [BindProperty]
        public Models.Item Item { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string categoryId, string statusId, string zoneid)
        {                
            Item.CategoryId = Convert.ToInt16(categoryId);
            Item.StatusId = Convert.ToInt16(statusId);
            int zid = Convert.ToInt16(zoneid);
            Item.Category = _context.Category.Find(Item.CategoryId);
            Item.Status = _context.Status.Find(Item.StatusId);

            if (!_context.Item.Any())
                Item.ItemSKU = 1;
            else
                Item.ItemSKU = _context.Item.Max(x => x.ItemSKU) + 1;
            _context.Item.Add(Item);
            await _context.SaveChangesAsync();

            if (zoneid != null)
            {
                var itemZone = new ItemZone();
                itemZone.ZoneId = zid;
                itemZone.ItemId = Item.ItemId;
                _context.ItemZones.Add(itemZone);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

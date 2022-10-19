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

namespace Garage003.Pages.Item
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Statuses { get; set; }
        public List<SelectListItem> Zones { get; set; }

        public EditModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Item Item { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

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
                                      Text = s.ZoneName
                                  }).ToList();

            var item =  await _context.Item.FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }
            Item = item;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string categoryId, string statusId, string zoneid)
        {
            Item.CategoryId = Convert.ToInt16(categoryId);
            Item.StatusId = Convert.ToInt16(statusId);
            int zid = Convert.ToInt16(zoneid);
            Item.Category = _context.Category.Find(Item.CategoryId);
            Item.Status = _context.Status.Find(Item.StatusId);

            _context.Attach(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Item.ItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            if (zoneid != null)
            {
                var itemZone = new ItemZone();
                itemZone.ZoneId = zid;
                itemZone.ItemId = Item.ItemId;
                _context.ItemZones.Add(itemZone);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }

        private bool ItemExists(int id)
        {
          return _context.Item.Any(e => e.ItemId == id);
        }
    }
}

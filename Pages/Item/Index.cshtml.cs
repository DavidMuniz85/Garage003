﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;

        public IndexModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Item> Item { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Item != null)
            {
                Item = await _context.Item.ToListAsync();
            }
        }
    }
}

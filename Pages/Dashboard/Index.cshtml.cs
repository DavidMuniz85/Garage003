using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Garage003.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly Garage003.Data.ApplicationDbContext _context;

        public IndexModel(Garage003.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Models.Item> ItemNames { get; set; } = default!;
        public IList<Models.Category> CategoryNames { get; set; } = default!;

        public void OnGet()
        {
            ItemNames = _context.Item.ToList();
            CategoryNames = _context.Category.ToList();
        }
    }
}

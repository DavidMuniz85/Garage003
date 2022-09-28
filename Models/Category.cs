using System.ComponentModel.DataAnnotations;

namespace Garage003.Models
{
    public class Category
    {
        private List<Item> _items;

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        //public ICollection<Item> Items { get; set; }
        public virtual List<Item> Items { get { return _items ?? (_items = new List<Item>()); } }
    }
}

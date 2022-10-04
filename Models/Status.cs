using System.ComponentModel.DataAnnotations;

namespace Garage003.Models
{
    public class Status
    {
        private List<Item> _items;

        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;

        public virtual List<Item> Items { get { return _items ?? (_items = new List<Item>()); } }
    }
}

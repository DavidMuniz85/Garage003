using System.ComponentModel.DataAnnotations;

namespace Garage003.Models
{
    public class Item
    {
        private List<ItemZone> _itemszones;
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int ItemSKU { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public virtual List<ItemZone> ItemsZones { get { return _itemszones ?? (_itemszones = new List<ItemZone>()); } }
    }
}
  
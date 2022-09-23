using System.ComponentModel.DataAnnotations;

namespace Garage003.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int ItemSKU { get; set; }
    }
}

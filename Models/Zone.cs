using System.ComponentModel.DataAnnotations;

namespace Garage003.Models
{
    public class Zone
    {
        private List<ItemZone> _itemszones;
        [Key]
        public int ZoneId { get; set; }
        public string ZoneName { get; set; } = string.Empty;

        public virtual List<ItemZone> ItemsZones { get { return _itemszones ?? (_itemszones = new List<ItemZone>()); } }
    }
}

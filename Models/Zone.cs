using System.ComponentModel.DataAnnotations;

namespace Garage003.Models
{
    public class Zone
    {
        [Key]
        public int ZoneId { get; set; }
        public string ZoneName { get; set; } = string.Empty;
    }
}

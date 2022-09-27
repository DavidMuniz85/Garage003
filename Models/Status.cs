using System.ComponentModel.DataAnnotations;

namespace Garage003.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Garage003.Models
{
    public class Garage
    {
        [Key]
        public int GarageId { get; set; }
        public string GarageName { get; set; } = string.Empty;
    }
}

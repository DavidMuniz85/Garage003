using System.ComponentModel.DataAnnotations;

namespace Garage003.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}

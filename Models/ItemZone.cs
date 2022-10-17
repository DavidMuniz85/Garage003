namespace Garage003.Models
{
    public class ItemZone
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }
    }
}

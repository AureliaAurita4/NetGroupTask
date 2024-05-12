using System.ComponentModel.DataAnnotations;

namespace NetGroupHomeTask.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAndTime { get; set; }
        public int MaxAudienceNumber { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetGroupHomeTask.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCode { get; set; }
        [ForeignKey("Event")]
        public string? EventId { get; set; }
        public List<Event> Events { get; set; }
    }
}

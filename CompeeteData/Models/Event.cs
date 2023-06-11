using System.ComponentModel.DataAnnotations;

namespace CompeeteData.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Adress { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public User User { get; set; }
    }
}

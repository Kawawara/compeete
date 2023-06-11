using System.ComponentModel.DataAnnotations;

namespace CompeeteData.Models
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime End { get; set; }
        public List<User>? Users { get; set; }
        public Event Event { get; set; }
        public Sport Sport { get; set; }
        public Constraint Constraint { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CompeeteData.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Sex { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Result> Results {get; set;}
        public List<Event> Event {get; set;}
    }
}

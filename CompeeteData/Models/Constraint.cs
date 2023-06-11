using System.ComponentModel.DataAnnotations;

namespace CompeeteData.Models
{
    public class Constraint
    {
        [Key]
        public int Id { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public string? Sex { get; set; }
        public int? MaxNumber { get; set; }
    }
}

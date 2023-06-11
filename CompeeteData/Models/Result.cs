using System.ComponentModel.DataAnnotations;

namespace CompeeteData.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public int? Score { get; set; }
        public int? Position { get; set; }
        public int? Chrono { get; set; }
        public User? User { get; set; }
        public Tournament? Tournament { get; set; }
    }
}

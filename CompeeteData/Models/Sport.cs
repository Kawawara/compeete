using System.ComponentModel.DataAnnotations;

namespace CompeeteData.Models
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BarbellHero.Models
{
    public class Movement
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

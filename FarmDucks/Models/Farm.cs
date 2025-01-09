using System.ComponentModel.DataAnnotations;

namespace FarmDucks.Models
{
    public class Farm : BaseEntity
    {
        [Required]
        public string Name { get; set; } = "";
        [Required]
        [MaxLength(500)]
        public string Location { get; set; } = "";
        public string? Notes { get; set; }
        public ICollection<Cycle> Cycles { get; set; } = new List<Cycle>();

    }
}

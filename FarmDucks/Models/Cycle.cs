using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmDucks.Models
{
    public class Cycle : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [Required]
        public DateTime BirthDate { get; set; }
        public string? Notes { get; set; }
        public ICollection<Duck> Ducks { get; set; } = new List<Duck>();
        public ICollection<CycleVaccine> CycleVaccines { get; set; } = new List<CycleVaccine>();
        public int FarmId { get; set; }
        [ForeignKey(nameof(FarmId))]
        public Farm Farm { get; set; }
    }
}
    
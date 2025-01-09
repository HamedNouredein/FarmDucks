using System.ComponentModel.DataAnnotations;

namespace FarmDucks.Models
{
    public class Vaccine: BaseEntity
    {
        [Required]
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }

        public string? Notes { get; set; }
        public bool IsTaken {  get; set; } = false;
        
        public ICollection<CycleVaccine> CycleVaccines { get; set; } = new List<CycleVaccine>();

    }
}

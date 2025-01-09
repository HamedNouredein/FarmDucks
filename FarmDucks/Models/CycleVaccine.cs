using System.ComponentModel.DataAnnotations.Schema;

namespace FarmDucks.Models
{
    public class CycleVaccine:BaseEntity
    {
        public int CycleId { get; set; }
        [ForeignKey(nameof(CycleId))]
        public Cycle Cycle { get; set; }
        public int VaccineId {  get; set; }
        [ForeignKey(nameof(VaccineId))]
        public Vaccine Vaccine { get; set; }

    }
}

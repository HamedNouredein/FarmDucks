using FarmDucks.Models;

namespace FarmDucks.ViewModels
{
    public class VaccineViewModel
    {
        public Vaccine Vaccine { get; set; } = new Vaccine();
        public IEnumerable<Cycle> Cycles { get; set; } = new List<Cycle>();
        public List<int> SelectedCycleIds { get; set; } = new List<int>(); // قائمة الدورات المختارة
    }
}

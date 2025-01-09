using FarmDucks.Models;

namespace FarmDucks.ViewModels
{
    public class DuckViewModel
    {
        public Duck Duck { get; set; } 
        public IEnumerable<Cycle> Cycles { get; set; }=new List<Cycle>();
    }
}

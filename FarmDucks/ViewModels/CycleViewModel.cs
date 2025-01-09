using FarmDucks.Models;

namespace FarmDucks.ViewModels
{
    public class CycleViewModel
    {
        
        public Cycle Cycle { get; set; } 
        public IEnumerable<Farm> Farms { get; set; }=new List<Farm>();
    }
}

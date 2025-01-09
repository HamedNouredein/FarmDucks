using FarmDucks.Data;
using FarmDucks.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmDucks.Repository
{
    public class CycleRepository:ICycleRepository
    {
        private readonly ApplicationDbContext _context;

        public CycleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cycle> GetAllCycles()
        {
            return _context.Cycles.Include(c => c.Farm).ToList();
        }


        public Cycle? GetCycleById(int id)
        {
            return _context.Cycles.Include(c => c.Ducks).Include(c => c.Farm).FirstOrDefault(c => c.Id == id);
        }

        public void AddCycle(Cycle cycle)
        {

            _context.Cycles.Add(cycle);
            _context.SaveChanges();

        }

        public void UpdateCycle(Cycle cycle)
        {
            var existingCycle = _context.Cycles.Find(cycle.Id);
            if (existingCycle != null)
            {
                _context.Entry(existingCycle).CurrentValues.SetValues(cycle);
                _context.SaveChanges();
            }
        }

        public bool DeleteCycle(int id)
        {
            var cycle = _context.Cycles.Find(id);
            if (cycle != null)
            {
                _context.Cycles.Remove(cycle);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

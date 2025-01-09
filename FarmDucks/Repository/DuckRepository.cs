using FarmDucks.Data;
using FarmDucks.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmDucks.Repository
{
    public class DuckRepository :IDuckRepository
    {
        private readonly ApplicationDbContext _context;

        public DuckRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Duck> GetAllDucks()
        {
            return _context.Ducks.Include(d => d.Cycle).ToList(); // تضمين الـ Cycle عند جلب الـ Ducks
        }

        public Duck? GetDuckById(int id)
        {
            return _context.Ducks.Include(d => d.Cycle).FirstOrDefault(d => d.Id == id);
        }

        public void AddDuck(Duck duck)
        {
            _context.Ducks.Add(duck);
            _context.SaveChanges();
        }

        public void UpdateDuck(Duck duck)
        {
            var existingDuck = _context.Ducks.Find(duck.Id);
            if (existingDuck != null)
            {
                _context.Entry(existingDuck).CurrentValues.SetValues(duck);
                _context.SaveChanges();
            }
        }

        public bool DeleteDuck(int id)
        {
            var duck = _context.Ducks.Find(id);
            if (duck != null)
            {
                _context.Ducks.Remove(duck);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

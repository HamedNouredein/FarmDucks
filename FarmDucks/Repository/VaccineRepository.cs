using FarmDucks.Data;
using FarmDucks.Models;

namespace FarmDucks.Repository
{
    public class VaccineRepository:IVaccineRepository
    {
        private readonly ApplicationDbContext _context;

        public VaccineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vaccine> GetAllVaccines()
        {
            return _context.Vaccines.ToList();
        }

        public Vaccine? GetVaccineById(int id)
        {
            return _context.Vaccines.FirstOrDefault(v => v.Id == id);
        }

        public void AddVaccine(Vaccine vaccine)
        {
            _context.Vaccines.Add(vaccine);
            _context.SaveChanges();
        }

        public void UpdateVaccine(Vaccine vaccine)
        {
            var existingVaccine = _context.Vaccines.Find(vaccine.Id);
            if (existingVaccine != null)
            {
                _context.Entry(existingVaccine).CurrentValues.SetValues(vaccine);
                _context.SaveChanges();
            }
        }

        public bool DeleteVaccine(int id)
        {
            var vaccine = _context.Vaccines.Find(id);
            if (vaccine != null)
            {
                _context.Vaccines.Remove(vaccine);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

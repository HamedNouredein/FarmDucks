using FarmDucks.Models;

namespace FarmDucks.Repository
{
    public interface IVaccineRepository
    {
        IEnumerable<Vaccine> GetAllVaccines();
        Vaccine? GetVaccineById(int id);
        void AddVaccine(Vaccine vaccine);
        void UpdateVaccine(Vaccine vaccine);
        bool DeleteVaccine(int id);
    }
}

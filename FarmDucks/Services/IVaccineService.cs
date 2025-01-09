using FarmDucks.Models;

namespace FarmDucks.Services
{
    public interface IVaccineService
    {
        IEnumerable<Vaccine> GetAllVaccines();
        Vaccine? GetVaccineById(int id);
        void AddVaccine(Vaccine vaccine);
        void UpdateVaccine(Vaccine vaccine);
        bool DeleteVaccine(int id);
    }
}

using FarmDucks.Data;
using FarmDucks.Models;
using FarmDucks.Repository;
using FarmDucks.Services;


namespace FarmDucks.Services
{
    public class VaccineService : IVaccineService
    {
       private readonly IVaccineRepository _vaccineRepository;

        public VaccineService(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public IEnumerable<Vaccine> GetAllVaccines()
        {
            return _vaccineRepository.GetAllVaccines();
        }

        public Vaccine? GetVaccineById(int id)
        {
            return _vaccineRepository.GetVaccineById(id);
        }

        public void AddVaccine(Vaccine vaccine)
        {
           _vaccineRepository.AddVaccine(vaccine);
        }

        public void UpdateVaccine(Vaccine vaccine)
        {
            _vaccineRepository.UpdateVaccine(vaccine);
        }

        public bool DeleteVaccine(int id)
        {
         return _vaccineRepository.DeleteVaccine(id);
        }
    }
}

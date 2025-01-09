using FarmDucks.Data;
using FarmDucks.Models;
using FarmDucks.Repository;

namespace FarmDucks.Services
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepository _farmRepository;

        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }
        public void AddFarm(Farm farm)
        {
            _farmRepository.AddFarm(farm);
        }

       
        public IEnumerable<Farm> GetAllFarm()
        {
            return _farmRepository.GetAllFarms();
        }

        public Farm? GetFarmById(int id)
        {
            return _farmRepository.GetFarmById(id);
        }

        public void UpdateFarm(Farm farm)
        {
            _farmRepository.UpdateFarm(farm);
        }
        public bool DeleteFarm(int id)
        {
           return _farmRepository.DeleteFarm(id);
        }


    }
}

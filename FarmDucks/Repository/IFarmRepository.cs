using FarmDucks.Models;

namespace FarmDucks.Repository
{
    public interface IFarmRepository
    {
        IEnumerable<Farm> GetAllFarms();
        Farm? GetFarmById(int id);
        void AddFarm(Farm farm);
        void UpdateFarm(Farm farm);
        bool DeleteFarm(int id);
    }
}

using FarmDucks.Models;

namespace FarmDucks.Services
{
    public interface IFarmService
    {
        IEnumerable<Farm> GetAllFarm();
        Farm? GetFarmById(int id);
        void AddFarm(Farm farm);
        void UpdateFarm(Farm farm);
        bool DeleteFarm(int id);
    }
}
